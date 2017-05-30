using CNC.Core.Data;
using CNC.Core.Security;
using Newtonsoft.Json;
using Shared.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNC.Forms
{
    public partial class FileExplorer : Form
    {
        public DriveInfo[] drives;
        Client currentClient;
        string currentPath;
        public FileExplorer(Client client)
        {
            currentClient = client;
            InitializeComponent();
            GetDrives();
        }

        public void GetDrives()
        {
            
            drives = JsonConvert.DeserializeObject<DriveInfo[]>(Cryptography.Decrypt(
                currentClient.Connection.SendReceiveObject<string, string>("GetDriveInfoReq", "GetDriveInfoRep", 10000,
                Cryptography.Encrypt(Guid.NewGuid().ToString()))));
              
            driveBox.Items.Clear();
            for (int i = 0; i < drives.Length; i++)
            {
                driveBox.Items.Add(new DrivesComboBoxEntry(drives[i].Name, drives[i]));
            }
            SetDir(drives[0].RootDirectory.FullName);
            driveBox.SelectedIndex = 0;
        }

        public void GetDirectoryInfo()
        {
            listViewCurrent.Items.Clear();
            
            FileEntry[] fe = JsonConvert.DeserializeObject<FileEntry[]>(
                Cryptography.Decrypt(currentClient.Connection.SendReceiveObject<string, string>("GetDirectoryContentReq", 
                "GetDirectoryContentRep", 20000, 
                Cryptography.Encrypt(currentPath))));
                

            for (int i = 0; i < fe.Length; i++)
            {
                listViewCurrent.Items.Add(new ListViewItem(new string[] { fe[i].Name, fe[i].Size, fe[i].Type.ToString(), fe[i].FullPath })
                {
                    Tag = fe[i]
                });
            }
        }

        public void SetDir(string path)
        {
            txtPath.Text = path;
            currentPath = path;
            GetDirectoryInfo();
        }

        private void driveBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrivesComboBoxEntry newDrive = (DrivesComboBoxEntry)driveBox.SelectedItem;
            SetDir(newDrive.Drive.RootDirectory.FullName);
        }

        private void listViewCurrent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                int index = listViewCurrent.FocusedItem.Index;
                FileEntry fe = (FileEntry)listViewCurrent.Items[index].Tag;
                if (fe.Type == FileEntry.type.Folder)
                {
                    SetDir(fe.FullPath);
                }
            }
        }

        private void txtPath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SetDir(txtPath.Text);
        }
    }
}
