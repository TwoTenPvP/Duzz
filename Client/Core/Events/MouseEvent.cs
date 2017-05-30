using Client.Core.Helper;
using Newtonsoft.Json;
using Shared.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core.Events
{
    class MouseEvent
    {
        public static void Execute(string data)
        {
            ScreenPoint newEvent = JsonConvert.DeserializeObject<ScreenPoint>(data);
            if (newEvent.eventType == ScreenPoint.EventType.Move)
            {
                Screen s = Screen.AllScreens[newEvent.Screen];
                double mouseX = (double)s.Bounds.Width * newEvent.X;
                double mouseY = (double)s.Bounds.Height * newEvent.Y;
                Cursor.Position = new System.Drawing.Point((int)mouseX, (int)mouseY);
            }
            else if (newEvent.eventType != ScreenPoint.EventType.Move)
            {
                Screen s = Screen.AllScreens[newEvent.Screen];
                double mouseX = (double)s.Bounds.Width * newEvent.X;
                double mouseY = (double)s.Bounds.Height * newEvent.Y;
                Cursor.Position = new System.Drawing.Point((int)mouseX, (int)mouseY);
                InputHelper.DoMouseClick(newEvent.eventType);
            }
        }       
    }
}
