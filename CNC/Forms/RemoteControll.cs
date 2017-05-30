using CNC.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared;
using Shared.Helper;
using CNC.Core.Security;
using Newtonsoft.Json;
using Shared.Objects;
using System.Diagnostics;
using CNC.Core.Helper;
using NetworkCommsDotNet;

namespace CNC.Forms
{
    public partial class RemoteControll : Form
    {
        private Client currentClient;
        private bool isListening;
        private DateTime lastFrameArrived;

        private ScreenPoint lastEvent;

        public RemoteControll(Client client)
        {
            InitializeComponent();
            currentClient = client;
            this.KeyPreview = true;
            this.KeyPress += KeyPressed;
        }

        private void KeyPressed(object sender, KeyPressEventArgs e)
        {
            if(isListening && chkControlKeyboard.Checked)
            {
                e.Handled = true;
                currentClient.Connection.SendObject<string>("SendKeyReq", Cryptography.Encrypt(e.KeyChar.ToString()));
            }
        }

        public void ListenForImages()
        {
            currentClient.Connection.AppendIncomingPacketHandler<byte[]>("ScreenshotSubmit", (header, connection, incomingBytes) =>
            {
              //  screenImage.Invoke( = BitmapConvert.byteArrayToImage(incomingBytes);
                if (screenImage.InvokeRequired)
                {
                    screenImage.Invoke(new MethodInvoker(delegate {
                        Image img = BitmapConvert.byteArrayToImage(incomingBytes);
                        int resizeMaxHeight = screenImage.MaximumSize.Height;
                        int resizeMaxWidth = screenImage.MaximumSize.Width;


                        double maxAspect = (double)resizeMaxWidth / (double)resizeMaxHeight;
                        double aspect = (double)img.Width / (double)img.Height;

                        if (maxAspect > aspect && img.Width > resizeMaxWidth)
                        {
                            //Width is the bigger dimension relative to max bounds
                            double resizeWidth = resizeMaxWidth;
                            double resizeHeight = resizeMaxWidth / aspect;
                            screenImage.Size = new Size((int)resizeWidth, (int)resizeHeight);

                        }
                        else if (maxAspect <= aspect && img.Height > resizeMaxHeight)
                        {
                            //Height is the bigger dimension
                            double resizeHeight = resizeMaxHeight;
                            double resizeWidth = resizeMaxHeight * aspect;
                            screenImage.Size = new Size((int)resizeWidth, (int)resizeHeight);
                        }
                        if (!screenImage.IsDisposed)
                            screenImage.Image = img;
                    }));
                }
                if(txtFps.InvokeRequired)
                {
                    txtFps.Invoke(new MethodInvoker(delegate { txtFps.Text = String.Format("{0} FPS", Math.Round(1d / (DateTime.UtcNow - lastFrameArrived).TotalSeconds, 1)); }));
                    lastFrameArrived = DateTime.UtcNow;
                }
            });
        }

        public void StopListenForImages()
        {
            currentClient.Connection.RemoveIncomingPacketHandler("ScreenshotSubmit");
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            if(isListening)
            {
                SubmitScreenStatus submitStatus = new SubmitScreenStatus()
                {
                    Refresh = (int)trkFps.Value,
                    Type = Shared.Enums.SubmitScreenStatusE.StopSubmit,
                    Monitor = (int)numericMonitor.Value
                };
                currentClient.Connection.SendObject<string>("SubmitScreenReq", Cryptography.Encrypt(JsonConvert.SerializeObject(submitStatus)));
                statusButton.Text = "Start";
                StopListenForImages();
                isListening = false;
            }
            else
            {
                SubmitScreenStatus submitStatus = new SubmitScreenStatus()
                {
                    Refresh = (int)trkFps.Value,
                    Type = Shared.Enums.SubmitScreenStatusE.StartSubmit,
                    Monitor = (int)numericMonitor.Value
                };
                currentClient.Connection.SendObject<string>("SubmitScreenReq", Cryptography.Encrypt(JsonConvert.SerializeObject(submitStatus)));
                statusButton.Text = "Stop";
                ListenForImages();
                isListening = true;
            }
        }

        private void numericMonitor_ValueChanged(object sender, EventArgs e)
        {
            SubmitScreenStatus submitStatus = new SubmitScreenStatus()
            {
                Refresh = (int)trkFps.Value,
                Type = Shared.Enums.SubmitScreenStatusE.ChangeMonitor,
                Monitor = (int)numericMonitor.Value
            };
            currentClient.Connection.SendObject<string>("SubmitScreenReq", Cryptography.Encrypt(JsonConvert.SerializeObject(submitStatus)));
        }

        private void RemoteControll_FormClosing(object sender, FormClosingEventArgs e)
        {
            SubmitScreenStatus submitStatus = new SubmitScreenStatus()
            {
                Refresh = (int)trkFps.Value,
                Type = Shared.Enums.SubmitScreenStatusE.StopSubmit,
                Monitor = (int)numericMonitor.Value
            };
            currentClient.Connection.SendObject<string>("SubmitScreenReq", Cryptography.Encrypt(JsonConvert.SerializeObject(submitStatus)));
            statusButton.Text = "Start";
            StopListenForImages();
            isListening = false;
        }

        private void screenImage_MouseMove(object sender, MouseEventArgs e)
        {
            //  Debug.Print(e.Location.ToString());
            //Debug.Print("X:" + ((double)e.Location.X / (double)screenImage.Size.Width).ToString() + "Y:" + ((double)e.Location.Y / (double)screenImage.Size.Height).ToString());
            ScreenPoint currentPoint = new ScreenPoint()
            {
                eventType = ScreenPoint.EventType.Move,
                Screen = (int)numericMonitor.Value,
                X = (double)e.Location.X / (double)screenImage.Size.Width,
                Y = (double)e.Location.Y / (double)screenImage.Size.Height
            };

            if(chkControlMouse.Checked && isListening && (lastEvent == null || ScreenHelper.DistanceBetweenScreenPoint(currentPoint, lastEvent) >= 0.001))
            {
                //We moved more than X.
                currentClient.Connection.SendObject<string>("MouseEventReq", Cryptography.Encrypt(JsonConvert.SerializeObject(currentPoint)));
                lastEvent = currentPoint;
            }
        }

        private void trkFps_Scroll(object sender, EventArgs e)
        {
            SubmitScreenStatus submitStatus = new SubmitScreenStatus()
            {
                Refresh = (int)trkFps.Value,
                Type = Shared.Enums.SubmitScreenStatusE.ChangeRefresh,
                Monitor = (int)numericMonitor.Value
            };
            currentClient.Connection.SendObject<string>("SubmitScreenReq", Cryptography.Encrypt(JsonConvert.SerializeObject(submitStatus)));
        }

        private void screenImage_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkControlMouse.Checked && isListening)
            {
                ScreenPoint.EventType type;
                if (e.Button == MouseButtons.Left)
                    type = ScreenPoint.EventType.LeftClick;
                else if (e.Button == MouseButtons.Right)
                    type = ScreenPoint.EventType.RightClick;
                else if (e.Button == MouseButtons.Middle)
                    type = ScreenPoint.EventType.MiddleMouse;
                else return;

                ScreenPoint currentPoint = new ScreenPoint()
                {
                    eventType = type,
                    Screen = (int)numericMonitor.Value,
                    X = (double)e.Location.X / (double)screenImage.Size.Width,
                    Y = (double)e.Location.Y / (double)screenImage.Size.Height
                };

                currentClient.Connection.SendObject<string>("MouseEventReq", Cryptography.Encrypt(JsonConvert.SerializeObject(currentPoint)));
                lastEvent = currentPoint;
            }
        }

        private void chkFreezeMouse_CheckedChanged(object sender, EventArgs e)
        {
            if(chkFreezeMouse.Checked)
            {
                ScreenPoint currentPoint = new ScreenPoint()
                {
                    eventType = ScreenPoint.EventType.Freeze,
                    Screen = (int)numericMonitor.Value,
                    X = 0,
                    Y = 0
                };

                if (isListening)
                {
                    //We moved more than X.
                    currentClient.Connection.SendObject<string>("MouseEventReq", Cryptography.Encrypt(JsonConvert.SerializeObject(currentPoint)));
                    lastEvent = currentPoint;
                }
            }
            else
            {
                ScreenPoint currentPoint = new ScreenPoint()
                {
                    eventType = ScreenPoint.EventType.Unfreeze,
                    Screen = (int)numericMonitor.Value,
                    X = 0,
                    Y = 0
                };

                if (isListening)
                {
                    //We moved more than X.
                    currentClient.Connection.SendObject<string>("MouseEventReq", Cryptography.Encrypt(JsonConvert.SerializeObject(currentPoint)));
                    lastEvent = currentPoint;
                }
            }
        }
    }
}
