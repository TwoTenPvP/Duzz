using CNC.Core.Data;
using CNC.Core.Security;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Shared.Objects;

namespace CNC.Forms
{
    public partial class RemoteScript : Form
    {
        Client currentClient;
        public RemoteScript(Client client)
        {
            currentClient = client;
            InitializeComponent();
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            string path = Path.GetTempPath();
            string fileName = "";
            if (radBAT.Checked)
                fileName = Guid.NewGuid().ToString() + ".bat";
            else if (radJS.Checked)
                fileName = Guid.NewGuid().ToString() + ".html";
            else if (radVB.Checked)
                fileName = Guid.NewGuid().ToString() + ".vbs";

            File.AppendAllText(Path.Combine(path, fileName), txtCode.Text);
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = Path.Combine(path, fileName),
                UseShellExecute = false,
                WindowStyle = chkRunSilent.Checked ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal,
                Verb = chkAdmin.Checked ? "runas" : null
            };
            Process.Start(psi);
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (radBAT.Checked)
                fileName = Guid.NewGuid().ToString() + ".bat";
            else if (radJS.Checked)
                fileName = Guid.NewGuid().ToString() + ".html";
            else if (radVB.Checked)
                fileName = Guid.NewGuid().ToString() + ".vbs";

            RemoteScriptInstruction rsi = new RemoteScriptInstruction()
            {
                Code = txtCode.Text,
                fileName = fileName,
                runAsAdmin = chkAdmin.Checked,
                runSilent = chkRunSilent.Checked
            };
            currentClient.Connection.SendObject<string>("RemoteScriptReq", Cryptography.Encrypt(JsonConvert.SerializeObject(rsi)));
        }
    }
}
