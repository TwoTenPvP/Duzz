using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Objects
{
    public class RemoteScriptInstruction
    {
        public string Code;
        public string fileName;
        public bool runAsAdmin;
        public bool runSilent;
    }
}
