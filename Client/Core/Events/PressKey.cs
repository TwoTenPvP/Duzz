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
            MessageBox.Show(data);
            Keys key = JsonConvert.DeserializeObject<Keys>(data);
            EnumKeyWrapper wp = new EnumKeyWrapper(key);
            SendKeys.SendWait(wp.ToString());
        }
    }
}
