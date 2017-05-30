using Client.Core.Networking;
using Client.Core.Security;
using Newtonsoft.Json;
using Shared.Objects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Events
{
    class GetDirectorContent
    {
        static readonly string[] SizeSuffixes =
          { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };

        public static void Execute(string path)
        {
            if (NetworkManager.IsConnected)
            {
                NetworkManager.Connection.SendObject("GetDirectoryContentRep",
                    Cryptography.Encrypt(JsonConvert.SerializeObject(GetFilesAndDirs(path))));
            }
            else
            {
                //TODO, Buffer / Packet queue of some sort
            }
        }


        private static FileEntry[] GetFilesAndDirs(string path)
        {
            if (Directory.Exists(path))
            {
                FileEntry[] files = new FileEntry[Directory.GetFiles(path).Length];
                for (int i = 0; i < Directory.GetFiles(path).Length; i++)
                {
                    FileInfo fi = new FileInfo(Directory.GetFiles(path)[i]);
                    files[i] = new FileEntry()
                    {
                        FullPath = fi.FullName,
                        Name = fi.Name,
                        Size = SizeSuffix(fi.Length),
                        Type = FileEntry.type.File
                    };
                }


                FileEntry[] dirs = new FileEntry[Directory.GetDirectories(path).Length];
                for (int i = 0; i < Directory.GetDirectories(path).Length; i++)
                {
                    DirectoryInfo fi = new DirectoryInfo(Directory.GetDirectories(path)[i]);
                    dirs[i] = new FileEntry()
                    {
                        FullPath = fi.FullName,
                        Name = fi.Name,
                        Size = "N/A",
                        Type = FileEntry.type.Folder
                    };
                }


                FileEntry[] fullArray = new FileEntry[dirs.Length + files.Length];
                Array.Copy(dirs, fullArray, dirs.Length);
                Array.Copy(files, 0, fullArray, dirs.Length, files.Length);
                return fullArray;
            }
            else
                return null;

        }

        static string SizeSuffix(Int64 value)
        {
            if (value < 0) { return "-" + SizeSuffix(-value); }

            int i = 0;
            decimal dValue = (decimal)value;
            while (Math.Round(dValue / 1024) >= 1)
            {
                dValue /= 1024;
                i++;
            }

            return string.Format("{0:n1} {1}", dValue, SizeSuffixes[i]);
        }

    }
}
