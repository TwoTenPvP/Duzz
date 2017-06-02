using CNC.Config;
using CNC.Core.Security;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNC.Core.Data
{
    public class Client
    {
        public string IPAddress;
        public string Country;
        public Connection Connection;
        public string OperatingSystem;
        public string Username;
        public string AccountType;
        public string UUID;


        public void SetOS()
        {
            OperatingSystem = Cryptography.Decrypt(Connection.SendReceiveObject<string, string>("0x05", "1x05", 10000, Cryptography.Encrypt(Guid.NewGuid().ToString())));
        }
        public void SetAccountType()
        {
            AccountType = Cryptography.Decrypt(Connection.SendReceiveObject<string, string>("0x01", "1x01", 10000, Cryptography.Encrypt(Guid.NewGuid().ToString())));
        }
        public void SetUserName()
        {
            Username = Cryptography.Decrypt(Connection.SendReceiveObject<string, string>("0x02", "1x02", 10000, Cryptography.Encrypt(Guid.NewGuid().ToString())));
        }
        public void SetUUID()
        {
            UUID = Cryptography.Decrypt(Connection.SendReceiveObject<string, string>("0x25", "1x25", 10000, Cryptography.Encrypt(Guid.NewGuid().ToString())));
        }

        public void Initialize()
        {
            SetOS();
            SetUserName();
            SetAccountType();
            SetUUID();
        }
    }
}
