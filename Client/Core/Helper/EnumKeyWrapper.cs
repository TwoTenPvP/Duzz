using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Helper
{
    class EnumKeyWrapper
    {
        public System.Windows.Forms.Keys key { get; set; }

        public EnumKeyWrapper(System.Windows.Forms.Keys key)
        {
            this.key = key;
        }

        public string ToString()
        {
            return "{" + key.ToString().ToUpper() + "}";
        }
    }
}
