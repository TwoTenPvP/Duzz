using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CNC.Core.Data
{
    public class DrivesComboBoxEntry
    {
        public string Display { get; set; }
        public DriveInfo Drive { get; set; }

        public DrivesComboBoxEntry(string display, DriveInfo drive)
        {
            Display = display;
            Drive = drive;
        }

        public override string ToString()
        {
            return Display;
        }
    }
}
