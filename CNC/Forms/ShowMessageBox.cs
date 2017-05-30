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
        private Client[] currentClients;
        public ShowMessageBox(Client[] clients)
        {
            currentClients = clients;
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            MessageBox.Show(txtMessage.Text);
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < currentClients.Length; i++)
            {
                currentClients[i].Connection.SendObject<string>("ShowMessageBoxReq", Cryptography.Encrypt(txtMessage.Text));
            }
        }
    }
}
