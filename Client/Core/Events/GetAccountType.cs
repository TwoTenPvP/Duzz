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
    class GetAccountType
    {
        public static void Execute(string data)
        {
            if (NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("GetAccountTypeRep", Cryptography.Encrypt(WindowsAccountHelper.GetAccountType()));
            }
            else
            {
                //TODO, Buffer / Packet queue of some sort
            }
        }
    }
}
