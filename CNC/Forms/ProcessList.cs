﻿using CNC.Core.Data;
using CNC.Core.Networking;
using CNC.Core.Security;
using Newtonsoft.Json;
using Shared;
using Shared.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNC.Forms
{
    public partial class ProcessList : Form
    {
        public Client currentClient;
        public ProcessList(Client client)
        {
            currentClient = client;
            InitializeComponent();
            RefreshProcess();
        }

        public void RefreshProcess()
        {
            List<DataProcess> dpList = JsonConvert.DeserializeObject<List<DataProcess>>(
                Cryptography.Decrypt(currentClient.Connection.SendReceiveObject<string, string>("0x03", "1x03", 10000, 
                Cryptography.Encrypt(Guid.NewGuid().ToString()))));

            processListView.Items.Clear();

            for (int i = 0; i < dpList.Count; i++)
            {
                processListView.Items.Add(new ListViewItem(new string[] { dpList[i].Id.ToString(), dpList[i].Name, dpList[i].WindowTitle }));
            }


            processListView.MouseClick += new MouseEventHandler((object sender, MouseEventArgs e) =>
            {
                if (e.Button == MouseButtons.Right)
                {
                    if (processListView.FocusedItem.Bounds.Contains(e.Location) == true)
                    {
                        ContextMenuStrip contextMenu = new ContextMenuStrip();

                        ToolStripItem item = contextMenu.Items.Add("Kill");
                        item.Click += new EventHandler(KillProcess);

                        contextMenu.Show(Cursor.Position);
                    }
                }
            });
        }

        public void KillProcess(object sender, EventArgs e)
        {
            ToolStripItem clickedItem = sender as ToolStripItem;

            currentClient.Connection.SendObject<string>("0x04", Cryptography.Encrypt(JsonConvert.SerializeObject(new DataProcess()
            {
                Id = Convert.ToInt32(processListView.FocusedItem.SubItems[0].Text),
                Name = processListView.FocusedItem.SubItems[1].Text
            })));
            RefreshProcess();
        }
    }
}
