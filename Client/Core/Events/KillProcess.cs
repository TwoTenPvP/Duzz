using Client.Core.Networking;
using Client.Core.Security;
using Newtonsoft.Json;
using Shared;
using Shared.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core.Events
{
    class KillProcess
    {
        public static void Execute(string data)
        {
            DataProcess dp = JsonConvert.DeserializeObject<DataProcess>(data);
            if (Process.GetProcessById(dp.Id) != null)
            {
                try
                {
                    Process.GetProcessById(dp.Id).Kill();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
