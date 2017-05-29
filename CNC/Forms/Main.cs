﻿using CNC.Config;
using CNC.Core.Data;
using CNC.Core.Networking;
using CNC.Forms;
using NetworkCommsDotNet;
using NetworkCommsDotNet.Connections;
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

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessList pl = new ProcessList(NetworkManager.Clients[0]);
            pl.Show();
        }
    }
}
