using Client.Core.Networking;
using Client.Core.Security;
using Newtonsoft.Json;
using Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core.Events
{
    class SetPowerState
    {
        public static void Execute(string data)
        {
            if (NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("SetPowerStateRep", Cryptography.Encrypt(Guid.NewGuid().ToString()));
            }
            else
            {
                //TODO, Buffer / Packet queue of some sort
            }

            PowerStateE ps = JsonConvert.DeserializeObject<PowerStateE>(data);
            switch(ps)
            {
                case PowerStateE.Hibernate:
                    Hibernate();
                    break;
                case PowerStateE.Restart:
                    Reboot();
                    break;
                case PowerStateE.Shutdown:
                    Shutdown();
                    break;
                case PowerStateE.Sleep:
                    Sleep();
                    break;
            }
        }

        private static void Shutdown()
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = "1";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }
        }

        private static void Reboot()
        {
            ManagementBaseObject mboShutdown = null;
            ManagementClass mcWin32 = new ManagementClass("Win32_OperatingSystem");
            mcWin32.Get();

            // You can't shutdown without security privileges
            mcWin32.Scope.Options.EnablePrivileges = true;
            ManagementBaseObject mboShutdownParams =
                     mcWin32.GetMethodParameters("Win32Shutdown");

            // Flag 1 means we want to shut down the system. Use "2" to reboot.
            mboShutdownParams["Flags"] = "0";
            mboShutdownParams["Reserved"] = "0";
            foreach (ManagementObject manObj in mcWin32.GetInstances())
            {
                mboShutdown = manObj.InvokeMethod("Win32Shutdown",
                                               mboShutdownParams, null);
            }
        }

        private static void Hibernate()
        {
            System.Windows.Forms.Application.SetSuspendState(PowerState.Hibernate, true, true);
        }

        private static void Sleep()
        {
            System.Windows.Forms.Application.SetSuspendState(PowerState.Suspend, true, true);
        }
    }
}
