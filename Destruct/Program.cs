using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Destruct
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread.Sleep(3000);
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i].StartsWith("_KILL_IT_"))
                {
                    string path = args[i]
                }
            }
        }
    }
}
