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
    class GetDriveInfo
    {
        public static void Execute(string data)
        {
            if (NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("GetDriveInfoRep", 
                    Cryptography.Encrypt(JsonConvert.SerializeObject(DriveInfo.GetDrives())));
            }
            else
            {
                //TODO, Buffer / Packet queue of some sort
            }
        }
    }
}
