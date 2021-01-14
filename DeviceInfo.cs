namespace USB_Locker
{
    class DeviceInfo
    {
        public string VolumeLetter { get; private set; }
        public string VolumeName { get; private set; }
        public string Model { get; private set; }
        public string SerialNumber { get; private set; }
        public long Size { get; private set; }
        public string Path { get; private set; }
        public long ProtectedFilesQuantity { get; private set; }

        public DeviceInfo(string volumeLetter, string volumeName, string model, string serialNumber, long size, string path)
        {
            this.VolumeLetter = volumeLetter;
            this.VolumeName = volumeName;
            this.Model = model;
            this.SerialNumber = serialNumber;
            this.Size = size;
            this.Path = path;
            this.ProtectedFilesQuantity = 0;
        }
    }
}
