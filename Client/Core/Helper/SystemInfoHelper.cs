using Shared.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Client.Core.Helper
{
    class SystemInfoHelper
    {
        public static SystemInfo GetSystemInfo()
        {
            return new SystemInfo
            {
                AccountType = WindowsAccountHelper.GetAccountType(),
                Username = WindowsAccountHelper.GetName(),
                CPUClockSpeed = GetCPUClockSpeed(),
                CPUManufacturer = GetCPUManufacturer(),
                CPUName = GetCPUName(),
                CPUVersion = GetCPUVersion(),
                GPUName = GetGPUName(),
                GPUMemoryType = GetGPUMemoryType(),
                MemoryManufacturer = GetMemoryManufacturer(),
                MemoryName = GetMemoryName(),
                MemoryCapacity = GetMemoryCapacity(),
                MemoryType = GetMemoryType(),
                MACAddress = GetMacAddress(),
                OperatingSystem = GetOperatingSystem()
            };
        }

        public static string GetMacAddress()
        {
            string macAddresses = "";

            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (nic.OperationalStatus == OperationalStatus.Up)
                {
                    macAddresses += nic.GetPhysicalAddress().ToString();
                    break;
                }
            }
            return macAddresses;
        }

        public static string GetGPUName()
        {
            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject obj in objvide.Get())
            {
                return obj["Name"].ToString();
            }
            return "";
        }

        public static string GetGPUMemoryType()
        {
            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");
            foreach (ManagementObject obj in objvide.Get())
            {
                return obj["VideoMemoryType"].ToString();
            }
            return "";
        }

        public static string GetCPUClockSpeed()
        {
            using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
                win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                    win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in win32Proc.Get())
                {
                    return obj["CurrentClockSpeed"].ToString();
                }
            }
            return "";
        }

        public static string GetCPUName()
        {
            using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
                win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                    win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in win32Proc.Get())
                {
                    return obj["Name"].ToString();
                }
            }
            return "";
        }

        public static string GetCPUManufacturer()
        {
            using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
                win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                    win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in win32Proc.Get())
                {
                    return obj["Manufacturer"].ToString();
                }
            }
            return "";
        }

        public static string GetCPUVersion()
        {
            using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
                win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                    win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in win32Proc.Get())
                {
                    return obj["Version"].ToString();
                }
            }
            return "";
        }

        public static string GetMemoryCapacity()
        {
            UInt64 capacity = 0;
            using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
            win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in win32Memory.Get())
                {
                    capacity += (UInt64)obj["Capacity"];
                }
            }

            return (Math.Round((double)capacity * 0.00000000093132)).ToString() + " GB";
        }

        public static string GetMemoryManufacturer()
        {
            using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
            win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in win32Memory.Get())
                {
                    return obj["Manufacturer"].ToString();
                }
            }
            return "";
        }

        public static string GetMemoryName()
        {
            using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
            win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in win32Memory.Get())
                {
                    return obj["Name"].ToString();
                }
            }
            return "";
        }

        public static string GetMemoryType()
        {
            using (ManagementObjectSearcher win32Proc = new ManagementObjectSearcher("select * from Win32_Processor"),
                win32CompSys = new ManagementObjectSearcher("select * from Win32_ComputerSystem"),
                    win32Memory = new ManagementObjectSearcher("select * from Win32_PhysicalMemory"))
            {
                foreach (ManagementObject obj in win32Memory.Get())
                {
                    return obj["MemoryType"].ToString();
                }
            }
            return "";
        }

        public static string GetOperatingSystem()
        {
            var name = (from x in new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem").Get().Cast<ManagementObject>()
                        select x.GetPropertyValue("Caption")).FirstOrDefault();
            return name != null ? name.ToString() : "Unknown";
        }
    }
}
