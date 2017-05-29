using CNC.Core.Networking;
using CNC.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CNC
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            NetworkManager.Listen();
            Application.Run(new Main());
        }

        private static void OnProcessExit(object sender, EventArgs e)
        {
            NetworkManager.Stop();
        }
    }
}
