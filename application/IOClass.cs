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
        private static readonly string UsersDataFilepath = @"C:\PAAK\users.json";

        #region IO User Data

        /// <summary>
        /// Creates root directory for application's data
        /// </summary>
        public static void CreateRootDirectory()
        {
            string path = @"C:\PAAK";

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        /// <summary>
        /// Saves new user in json file
        /// </summary>
        /// <param name="user"></param>
        /// <returns>True if saving went successful</returns>
        public static bool SaveNewUser(User user, string username)
        {
            string path = @"C:\PAAK\" + username;

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            List<User> usersList = ReadUsersList();
            if (usersList.Count == 0)
                user.SetID(1);
            else
                user.SetID(usersList.Count + 1);

            usersList.Add(user);
            string jsonString = JsonConvert.SerializeObject(usersList.ToArray(), Formatting.Indented);
            File.WriteAllText(UsersDataFilepath, jsonString);
            return true;
        }

        /// <summary>
        /// Updates user's record 
        /// </summary>
        /// <param name="updatedUser">Updated object</param>
        /// <returns></returns>
        public static bool UpdateUser(User updatedUser)
        {
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
            File.WriteAllText(UsersDataFilepath, jsonString);
            return true;
        }

        /// <summary>
        /// Reads users list from json file
        /// </summary>
        /// <returns>List of user objects</returns>
        public static List<User> ReadUsersList()
        {
            List<User> usersList = new List<User>();

            if (File.Exists(UsersDataFilepath))
            {
                string jsonString = File.ReadAllText(UsersDataFilepath);
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
        public static List<string> ReadFoldersList(string filepath)
        {
            List<string> folders = new List<string>();

            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                folders = JsonConvert.DeserializeObject<List<string>>(jsonString);
            }

            return folders;
        }

        /// <summary>
        /// Saves folder paths list in json file
        /// </summary>
        /// <param name="folderPaths"></param>
        /// <returns>True if saving went successful</returns>
        public static bool SaveFoldersList(List<string> folderPaths, string filepath)
        {
            string jsonString = JsonConvert.SerializeObject(folderPaths.ToArray(), Formatting.Indented);
            File.WriteAllText(filepath, jsonString);
            return true;
        }

        #endregion

        #region IO Trsuted Devices Data

        /// <summary>
        /// Saves trusted devices list in json file
        /// </summary>
        /// <param name="trustedDevices"></param>
        /// <returns>True if saving went successful</returns>
        public static bool SaveTrustedDevicesList(List<Device> trustedDevices, string filepath)
        {
            string jsonString = JsonConvert.SerializeObject(trustedDevices.ToArray(), Formatting.Indented);
            File.WriteAllText(filepath, jsonString);
            return true;
        }

        /// <summary>
        /// Reads trusted devices list from json file
        /// </summary>
        /// <returns>List of trusted devices objects</returns>
        public static List<Device> ReadTrustedDevicesList(string filepath)
        {
            List<Device> devices = new List<Device>();

            if (File.Exists(filepath))
            {
                string jsonString = File.ReadAllText(filepath);
                devices = JsonConvert.DeserializeObject<List<Device>>(jsonString);
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
