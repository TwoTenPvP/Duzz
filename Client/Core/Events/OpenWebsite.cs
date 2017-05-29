using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Events
{
    class OpenWebsite
    {
        public static void Execute(string data)
        {
            try
            {
                Process.Start(data);
            }
            catch
            {

            }
        }
    }
}
