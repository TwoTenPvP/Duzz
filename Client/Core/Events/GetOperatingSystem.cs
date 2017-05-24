using Client.Core.Networking;
using Client.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Events
{
    class GetOperatingSystem
    {
        public static void Run(string data)
        {
            if(NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("GetOperatingSystem", Cryptography.Encrypt(Environment.OSVersion.ToString()));
            }
            else
            {
                //TODO, Buffer / Packet queue of some sort
            }
        }
    }
}
