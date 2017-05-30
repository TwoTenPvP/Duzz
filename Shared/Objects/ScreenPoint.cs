using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Objects
{
    public class ScreenPoint
    {
        public double X;
        public double Y;
        public int Screen;
        public enum EventType
        {
            LeftClick,
            RightClick,
            MiddleMouse,
            Move,
            Freeze,
            Unfreeze
        };
        public EventType eventType;
    }
}
