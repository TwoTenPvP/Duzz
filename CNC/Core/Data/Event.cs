using CNC.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC.Core.Data
{
    public class Event
    {
        public EventType OnEvent;
        public EventDoType DoEvent;
        public string DoEventParams;
        public bool Active;
    }
}
