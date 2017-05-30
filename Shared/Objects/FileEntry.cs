using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Objects
{
    public class FileEntry
    {
        public string FullPath;
        public string Name;
        public type Type;
        public int Size;
        public enum type
        {
            File,
            Folder
        }
    }
}
