using Client.Core.Helper;
using Client.Core.Networking;
using Client.Core.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Events
{
    class GetUserName
    {
        public static void Execute(string data)
        {
            if (NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("GetUserNameRep", Cryptography.Encrypt(WindowsAccountHelper.GetName()));
            }
            else
            {
                //TODO, Buffer / Packet queue of some sort
            }
        }
    }
}
