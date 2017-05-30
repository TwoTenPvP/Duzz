using Client.Core.Helper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core.Events
{
    class PressKey
    {
        public static void Execute(string data)
        {
            SendKeys.SendWait(data);
        }
    }
}
