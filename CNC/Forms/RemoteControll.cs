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

namespace CNC.Forms
{
    public partial class RemoteControll : Form
    {
        private Client currentClient;
        private bool isListening;
        private DateTime lastFrameArrived;

        public RemoteControll(Client client)
        {
            InitializeComponent();
            currentClient = client;
        }


        public void ListenForImages()
        {
            currentClient.Connection.AppendIncomingPacketHandler<byte[]>("ScreenshotSubmit", (header, connection, incomingBytes) =>
            {
              //  screenImage.Invoke( = BitmapConvert.byteArrayToImage(incomingBytes);
                if (screenImage.InvokeRequired)
                {
                    screenImage.Invoke(new MethodInvoker(delegate { screenImage.Image = BitmapConvert.byteArrayToImage(incomingBytes); }));
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
            this.Text = "Remote Control (OFF)";
        }

        private void statusButton_Click(object sender, EventArgs e)
        {
            if(isListening)
            {
                SubmitScreenStatus submitStatus = new SubmitScreenStatus()
                {
                    Refresh = (int)numericFrameRate.Value,
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
                    Refresh = (int)numericFrameRate.Value,
                    Type = Shared.Enums.SubmitScreenStatusE.StartSubmit,
                    Monitor = (int)numericMonitor.Value
                };
                currentClient.Connection.SendObject<string>("SubmitScreenReq", Cryptography.Encrypt(JsonConvert.SerializeObject(submitStatus)));
                statusButton.Text = "Stop";
                ListenForImages();
                isListening = true;
            }
        }

        private void numericFrameRate_ValueChanged(object sender, EventArgs e)
        {
            SubmitScreenStatus submitStatus = new SubmitScreenStatus()
            {
                Refresh = (int)numericFrameRate.Value,
                Type = Shared.Enums.SubmitScreenStatusE.ChangeRefresh,
                Monitor = (int)numericMonitor.Value
            };
            currentClient.Connection.SendObject<string>("SubmitScreenReq", Cryptography.Encrypt(JsonConvert.SerializeObject(submitStatus)));
        }

        private void numericMonitor_ValueChanged(object sender, EventArgs e)
        {
            SubmitScreenStatus submitStatus = new SubmitScreenStatus()
            {
                Refresh = (int)numericFrameRate.Value,
                Type = Shared.Enums.SubmitScreenStatusE.ChangeRefresh,
                Monitor = (int)numericMonitor.Value
            };
            currentClient.Connection.SendObject<string>("SubmitScreenReq", Cryptography.Encrypt(JsonConvert.SerializeObject(submitStatus)));
        }

        private void RemoteControll_FormClosing(object sender, FormClosingEventArgs e)
        {
            SubmitScreenStatus submitStatus = new SubmitScreenStatus()
            {
                Refresh = (int)numericFrameRate.Value,
                Type = Shared.Enums.SubmitScreenStatusE.StopSubmit,
                Monitor = (int)numericMonitor.Value
            };
            currentClient.Connection.SendObject<string>("SubmitScreenReq", Cryptography.Encrypt(JsonConvert.SerializeObject(submitStatus)));
            statusButton.Text = "Start";
            StopListenForImages();
            isListening = false;
        }
    }
}
