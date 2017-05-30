using Client.Core.Helper;
using Newtonsoft.Json;
using Shared.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core.Events
{
    class MouseEvent
    {
        public static ScreenPoint MouseFreezePosition;
        public static Thread MouseFreezeThread;
        private static object _lockMousePos = new object();

        public static void Execute(string data)
        {
            ScreenPoint newEvent = JsonConvert.DeserializeObject<ScreenPoint>(data);
            if (newEvent.eventType == ScreenPoint.EventType.Move)
            {
                lock(_lockMousePos)
                {
                    Screen s = Screen.AllScreens[newEvent.Screen];
                    double mouseX = (double)s.Bounds.Width * newEvent.X;
                    double mouseY = (double)s.Bounds.Height * newEvent.Y;
                    Cursor.Position = new System.Drawing.Point((int)mouseX, (int)mouseY);
                    MouseFreezePosition = newEvent;
                }
            }
            else if(newEvent.eventType != ScreenPoint.EventType.Unfreeze && newEvent.eventType != ScreenPoint.EventType.Freeze)
            {
                lock(_lockMousePos)
                {
                    Screen s = Screen.AllScreens[newEvent.Screen];
                    double mouseX = (double)s.Bounds.Width * newEvent.X;
                    double mouseY = (double)s.Bounds.Height * newEvent.Y;
                    Cursor.Position = new System.Drawing.Point((int)mouseX, (int)mouseY);
                    MouseFreezePosition = newEvent;
                    InputHelper.DoMouseClick(newEvent.eventType);
                }
            }
            else if(newEvent.eventType == ScreenPoint.EventType.Unfreeze)
            {
                //Unfreeze
                lock (_lockMousePos)
                    MouseFreezeThread.Abort();
            }
            else if(newEvent.eventType == ScreenPoint.EventType.Freeze)
            {
                //Freeze
                lock(_lockMousePos)
                {
                    MouseFreezePosition = newEvent;
                    MouseFreezeThread = new Thread(FreezeMouse);
                    MouseFreezeThread.Start();
                }
            }
        }


        private static void FreezeMouse()
        {
            while(true)
            {
                Screen s = Screen.AllScreens[MouseFreezePosition.Screen];
                double mouseX = (double)s.Bounds.Width * MouseFreezePosition.X;
                double mouseY = (double)s.Bounds.Height * MouseFreezePosition.Y;
                Cursor.Position = new System.Drawing.Point((int)mouseX, (int)mouseY);
            }
        }
    }
}
