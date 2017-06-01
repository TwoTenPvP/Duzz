using Client.Core.Helper;
using Client.Core.Networking;
using Client.Core.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Events
{
    class GetSystemInfo
    {
        public static void Execute(string data)
        {
            NetworkManager.Connection.SendObject("GetSystemInfoRep", 
                Cryptography.Encrypt(JsonConvert.SerializeObject(SystemInfoHelper.GetSystemInfo())));
        }
    }
}
