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
        static Mutex mutex = new Mutex(true, "DUZZ_MUTX_586453c8-147e-4947-9ae6-1b55f93f883b");
        [STAThread]
        static void Main()
        {
            if (mutex.WaitOne(TimeSpan.Zero, true))
            {
                //ENTRY
                NetworkManager.Connect();
                NetworkManager.StartReconnect();

                mutex.ReleaseMutex();
            }
            else
            {
                //Mulitple instances!
            }
        }
    }
}
