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


        public void SetOS()
        {
            OperatingSystem = Cryptography.Decrypt(Connection.SendReceiveObject<string, string>("GetOperatingSystemReq", "GetOperatingSystemRep", 10000, Cryptography.Encrypt(Guid.NewGuid().ToString())));
        }

        public void Initialize()
        {
            SetOS();
        }
    }
}
