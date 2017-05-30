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

        private ImageList imgList;
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

            imgList = new ImageList();
            listViewCurrent.SmallImageList = imgList;
            listViewCurrent.LargeImageList = imgList;

            for (int i = 0; i < fe.Length; i++)
            {
                Icon iconForFile = SystemIcons.Error;
                if (fe[i].Type == FileEntry.type.File)
                {
                    iconForFile = Icon.ExtractAssociatedIcon(fe[i].FullPath);
                    if (!imgList.Images.ContainsKey(Path.GetExtension(fe[i].FullPath)))
                    {
                        // If not, add the image to the image list.
                        iconForFile = System.Drawing.Icon.ExtractAssociatedIcon(fe[i].FullPath);
                        imgList.Images.Add(Path.GetExtension(fe[i].FullPath), iconForFile);
                    }
                }
                else if(fe[i].Type == FileEntry.type.Folder)
                {
                    iconForFile = iconForFile = Properties.Resources.folder_icon;
                    if (!imgList.Images.ContainsKey("folder"))
                    {
                        // If not, add the image to the image list.
                        iconForFile = Properties.Resources.folder_icon;
                        imgList.Images.Add("folder", iconForFile);
                    }
                }

                listViewCurrent.Items.Add(new ListViewItem(new string[] { fe[i].Name, fe[i].Size, fe[i].Type.ToString() })
                {
                    Tag = fe[i],
                    ImageKey = fe[i].Type == FileEntry.type.Folder ? "folder" : Path.GetExtension(fe[i].FullPath)
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

        private void listViewCurrent_MouseClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                //TODO: Context menu strip with Copy, delete etc
     
            }
        }
    }
}
