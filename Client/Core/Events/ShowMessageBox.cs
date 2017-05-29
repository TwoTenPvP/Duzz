using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Core.Events
{
    class ShowMessageBox
    {
        public static void Execute(string data)
        {
            MessageBox.Show(data);
        }
    }
}
