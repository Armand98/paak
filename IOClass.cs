using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace USB_Locker
{
    /// <summary>
    /// Provides all data input and output methods
    /// </summary>
    static class IOClass
    {

        #region IO User Data

        /// <summary>
        /// Saves new user in json file
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if saving went successful</returns>
        public static bool SaveNewUser(User user)
        {
            string filePath = @"C:\temp\users.json";
            List<User> usersList = ReadUsersList();
            if (usersList.Count == 0)
                user.SetID(1);
            else
                user.SetID(usersList.Count + 1);

            usersList.Add(user);
            string jsonString = JsonConvert.SerializeObject(usersList.ToArray(), Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
            return true;
        }

        /// <summary>
        /// Updates user's record 
        /// </summary>
        /// <param name="updatedUser">Updated object</param>
        /// <returns></returns>
        public static bool UpdateUser(User updatedUser)
        {
            string filePath = @"C:\temp\users.json";
            List<User> usersList = ReadUsersList();
            foreach(User user in usersList)
            {
                if(user.GetUsername().Equals(updatedUser.GetUsername()))
                {
                    usersList.Remove(user);
                    usersList.Add(updatedUser);
                    break;
                }
            }
            string jsonString = JsonConvert.SerializeObject(usersList.ToArray(), Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
            return true;
        }

        /// <summary>
        /// Reads users list from json file
        /// </summary>
        /// <returns>List of user objects</returns>
        public static List<User> ReadUsersList()
        {
            List<User> usersList = new List<User>();
            string filePath = @"C:\temp\users.json";

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                usersList = JsonConvert.DeserializeObject<List<User>>(jsonString);
            }

            return usersList;
        }

        #endregion

        #region IO Files Data

        /// <summary>
        /// Saves file paths list in json file
        /// </summary>
        /// <param name="filePaths"></param>
        /// <returns>True if saving went successful</returns>
        public static bool SaveFilesList(List<string> filePaths, string filepath)
        {
            string jsonString = JsonConvert.SerializeObject(filePaths.ToArray(), Formatting.Indented);
            File.WriteAllText(filepath, jsonString);
            return true;
        }

        /// <summary>
        /// Reads file paths list from json file
        /// </summary>
        /// <returns>List of file paths</returns>
        public static List<string> ReadFilesList(string filepath)
        {
            List<string> files = new List<string>();

            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                files = JsonConvert.DeserializeObject<List<string>>(jsonString);
            }

            return files;
        }

        #endregion

        #region IO Folders Data

        /// <summary>
        /// Reads folder paths list from json file
        /// </summary>
        /// <returns>List of folder paths</returns>
        public static List<string> ReadFoldersList()
        {
            List<string> folders = new List<string>();
            string filePath = @"C:\temp\folders.json";

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                folders = JsonConvert.DeserializeObject<List<string>>(jsonString);
            }

            return folders;
        }

        /// <summary>
        /// Saves folder paths list in json file
        /// </summary>
        /// <param name="folderPaths"></param>
        /// <returns>True if saving went successful</returns>
        public static bool SaveFoldersList(List<string> folderPaths)
        {
            string filePath = @"C:\temp\folders.json";
            string jsonString = JsonConvert.SerializeObject(folderPaths.ToArray(), Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
            return true;
        }

        #endregion

        #region IO Trsuted Devices Data

        /// <summary>
        /// Saves trusted devices list in json file
        /// </summary>
        /// <param name="trustedDevices"></param>
        /// <returns>True if saving went successful</returns>
        public static bool SaveTrustedDevicesList(List<DeviceInfo> trustedDevices)
        {
            string filePath = @"C:\temp\data.json";
            string jsonString = JsonConvert.SerializeObject(trustedDevices.ToArray(), Formatting.Indented);
            File.WriteAllText(filePath, jsonString);
            return true;
        }

        /// <summary>
        /// Reads trusted devices list from json file
        /// </summary>
        /// <returns>List of trusted devices objects</returns>
        public static List<DeviceInfo> ReadTrustedDevicesList()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();
            string filePath = @"C:\temp\data.json";

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                devices = JsonConvert.DeserializeObject<List<DeviceInfo>>(jsonString);
            }
            return devices;
        }

        /// <summary>
        /// Saves RSA private key on trusted device
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>True if saving went successful</returns>
        public static bool SavePrivateKeyOnDevice(string filepath, string privateKey)
        {
            if (File.Exists(filepath))
            {
                File.SetAttributes(filepath, FileAttributes.Normal);
                File.Delete(filepath);
            }
            File.WriteAllText(filepath, privateKey);
            File.SetAttributes(filepath, FileAttributes.Hidden | FileAttributes.ReadOnly);
            return true;
        }

        /// <summary>
        /// Removes private key from device
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>True if removal went successful</returns>
        public static bool RemovePrivateKeyFromDevice(string filepath)
        {
            if(File.Exists(filepath))
            {
                File.SetAttributes(filepath, FileAttributes.Normal);
                File.Delete(filepath);
            }
            return true;
        }

        /// <summary>
        /// Reads private key from device
        /// </summary>
        /// <param name="filepath"></param>
        /// <returns>Private key as stringXML</returns>
        public static string ReadPrivateKeyFromDeviceToString(string filepath)
        {
            string xmlString = string.Empty;
            if (File.Exists(filepath))
            {
                xmlString = File.ReadAllText(filepath);
            }
            return xmlString;
        }
        #endregion
    }
}
