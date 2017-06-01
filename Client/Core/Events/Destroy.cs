using Microsoft.CSharp;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core.Events
{
    class Destroy
    {
        public static void Execute(string data)
        {
            CreateKiller();
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

        static void CreateKiller()
        {
            string deletePath = Application.ExecutablePath; 
            string killerPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString().Replace("-", "") + ".exe");
            var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll", "System.dll" }, killerPath, true);
            parameters.GenerateExecutable = true;
            CompilerResults results = csc.CompileAssemblyFromSource(parameters,
            @"using System.Linq;
              using System;
              using System.Diagnostics;
              using System.Threading;
              using System.IO;
            class Program {
              public static void Main(string[] args) {
                string exe = @" + "\"" + deletePath + "\";" + @"
                
                Thread.Sleep(2500);
                File.Delete(exe);
                }
            }");
            results.Errors.Cast<CompilerError>().ToList().ForEach(error => Debug.Print(error.ErrorText + " Line: " + error.Line + "Column: " + error.Column));
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                WindowStyle = ProcessWindowStyle.Hidden,
                UseShellExecute = true,
                FileName = killerPath
            };
            Process.Start(startInfo);
        }
    }
}
