﻿using Client.Config;
using Client.Core.Events;
using Client.Core.Helper;
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
            }
            else
            {
                //Mulitple instances!
            }
        }
    }
}
