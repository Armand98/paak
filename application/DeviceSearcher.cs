using System;
using System.Collections.Generic;
using System.Management;

namespace USB_Locker
{
    static class DeviceSearcher
    {
        /// <summary>
        /// Provides 
        /// </summary>
        /// <returns>List of Device objects</returns>
        public static List<Device> ReadConnectedDevices()
        {
            List<Device> devices = new List<Device>();

            ManagementObjectSearcher diskDrives = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive WHERE InterfaceType='USB'");
            foreach (ManagementObject diskDrive in diskDrives.Get())
            {
                string DeviceID = diskDrive["DeviceID"].ToString();
                string DriveLetter = "";
                string DriveDescription = "";

                ManagementObjectSearcher partitionSearcher = new ManagementObjectSearcher(String.Format(
                    "associators of {{Win32_DiskDrive.DeviceID='{0}'}} where AssocClass = Win32_DiskDriveToDiskPartition",
                    diskDrive["DeviceID"]));

                foreach (ManagementObject partition in partitionSearcher.Get())
                {
                    ManagementObjectSearcher logicalSearcher = new ManagementObjectSearcher(String.Format(
                        "associators of {{Win32_DiskPartition.DeviceID='{0}'}} where AssocClass = Win32_LogicalDiskToPartition",
                        partition["DeviceID"]));

                    foreach (ManagementObject logical in logicalSearcher.Get())
                    {
                        ManagementObjectSearcher volumeSearcher = new ManagementObjectSearcher(String.Format(
                            "select * from Win32_LogicalDisk where Name='{0}'",
                            logical["Name"]));

                        foreach (ManagementObject volume in volumeSearcher.Get())
                        {
                            DriveLetter = volume["Name"].ToString();
                            if (volume["VolumeName"] != null)
                                DriveDescription = volume["VolumeName"].ToString();

                            char volumeLetter = DriveLetter[0];
                            string volumeName = DriveDescription;
                            string model = (string)diskDrive["Model"];
                            string serialNumber = (string)diskDrive["SerialNumber"];
                            long size = Convert.ToInt64(volume["Size"]);
                            string path = volumeLetter + @":\PAAK_PrivateKey.xml";

                            devices.Add(new Device(volumeLetter.ToString(), volumeName, model, serialNumber, size, path));
                        }
                    }
                }
            }
            return devices;
        }
    }
}
