using System;
using System.Collections.Generic;
using System.Windows;
using System.Management;
using System.Windows.Media;
using System.Threading;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.Windows.Input;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace USB_Locker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members

        private List<DeviceInfo> ConnectedDevices;
        private List<DeviceInfo> TrustedDevices;
        private List<DeviceInfo> ConnectedTrustedDevices;
        private List<string> Files;
        private List<string> EncryptedFiles;
        private List<string> Folders;
        private bool DeviceListChanged;
        private User LoggedUser;
        private string Username;
        private string RsaPrivateKey;
        private string UserFilesFilepath;
        private string UserEncryptedFilesFilepath;
        private string UserFoldersFilepath;
        private string UserKeyDataFilepath;
        private bool DidUserLoggedUnauthorized;
        private bool AuthorizationStatus;

        #endregion

        /*
         * Stworzyć lepszą walidację zaznaczonych elementów listboxów by operacje nie były dozwolone na obiektach null, które powodują NullReferenceException
         */

        #region Constructor

        /// <summary>
        /// Sets default values and starts a new task which checks connected devices 
        /// </summary>
        public MainWindow(string username)
        {
            InitializeComponent();
            
            DidUserLoggedUnauthorized = true;
            DeviceListChanged = false;
            deleteTrustedDeviceBtn.IsEnabled = false;
            labelUsername.Content = "Hello " + username;
            RsaPrivateKey = string.Empty;
            AuthorizationStatus = false;
            this.Username = username;
            List<User> usersList = IOClass.ReadUsersList();
            string hashedUsername = DataCryptography.SHA512(username);

            bindFilesListBox();
            bindFoldersListBox();

            foreach (User user in usersList)
            {
                if (user.GetUsername().Equals(hashedUsername))
                {
                    LoggedUser = user;
                }
            }

            labelSecurityQuestion.Content = LoggedUser.GetQuestion();

            this.UserFilesFilepath = @"C:\PAAK\" + username + @"\files.json";
            this.UserFoldersFilepath = @"C:\PAAK\" + username + @"\folders.json";
            this.UserKeyDataFilepath = @"C:\PAAK\" + username + @"\data.json";
            this.UserEncryptedFilesFilepath = @"C:\PAAK\" + username + @"\encryptedFiles.json";

            var uiSyncContext = SynchronizationContext.Current;

            var loopTask = Task.Run(() =>
            {
                while(true)
                {
                    Task.Delay(1000);

                    UpdateConnectedDevices();
                    if(DeviceListChanged)
                    {
                        if (ConnectedTrustedDevices != null)
                        {
                            if (ConnectedTrustedDevices.Count.Equals(1))
                            {
                                AuthorizationStatus = true;
                                if (RsaPrivateKey.Equals(string.Empty))
                                {
                                    RsaPrivateKey = IOClass.ReadPrivateKeyFromDeviceToString(ConnectedTrustedDevices[0].Path);
                                }
                            }
                            else
                            {
                                AuthorizationStatus = false;
                            }
                        }
                        
                        uiSyncContext.Post((s) =>
                        {
                            UpdateDevicesStatus();
                        }, null);
                    }
                }
            });
        }

        #endregion

        #region UI Event Methods

        /// <summary>
        /// Allows user to drag and drop main window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        /// <summary>
        /// Authorizes a new device to act as an authentication key by adding it to the trusted devices list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show(listBoxConnectedDevices.SelectedItem.ToString(), "Do you want to use this device as an authentication key?", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result.Equals(MessageBoxResult.Yes))
            {
                addTrustedDevice(listBoxConnectedDevices.SelectedItem.ToString());
                bindDeviceListBoxes();
            }
        }

        /// <summary>
        /// Enable selection button when device has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxConnectedDevices_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            submitButton.IsEnabled = true;
        }

        /// <summary>
        /// Deletes a device from trusted devices list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteTrustedDeviceBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result1 = MessageBox.Show("Do you want to delete " + listBoxTrustedDevices.SelectedItem.ToString() + "?", "Delete an authentication key?", MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result1.Equals(MessageBoxResult.Yes))
            {
                if (Files.Count > 0)
                {
                    MessageBoxResult result2 = MessageBox.Show("You want to delete a key with associated files with it. " +
                        "They will no longer be protected! Are you sure?", "Associated files found!", MessageBoxButton.YesNo, MessageBoxImage.Warning);

                    if (result2.Equals(MessageBoxResult.Yes))
                    {
                        Files.Clear();
                        IOClass.SaveFilesList(Files, this.UserFilesFilepath);
                        bindFilesListBox();
                        bindDeviceListBoxes();

                        if (deleteTrustedDevice(listBoxTrustedDevices.SelectedItem.ToString()))
                        {
                            MessageBox.Show("The authentication key has been deleted.", "Deleting successful", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("Couldn't delete an authentication key.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
                else
                {
                    if (deleteTrustedDevice(listBoxTrustedDevices.SelectedItem.ToString()))
                    {
                        MessageBox.Show("The authentication key has been deleted.", "Deleting successful", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Couldn't delete an authentication key.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        /// <summary>
        /// Enables removal button when device has been selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBoxTrustedDevices_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            deleteTrustedDeviceBtn.IsEnabled = true;
        }

        /// <summary>
        /// Activates Ffle dialog and saves file paths that will be protected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog fileDialog = new CommonOpenFileDialog
            {
                InitialDirectory = @"C:\",
                Multiselect = true
            };

            if (fileDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Files = IOClass.ReadFilesList(this.UserFilesFilepath);
                Files.AddRange(fileDialog.FileNames);
                listBoxFiles.ItemsSource = Files;
                IOClass.SaveFilesList(Files, this.UserFilesFilepath);
            }
        }

        /// <summary>
        /// Activates File Dialog and saves folder paths that will be protected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addFoldersBtn_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog
            {
                InitialDirectory = @"C:\",
                IsFolderPicker = true
            };

            if (folderDialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Folders = IOClass.ReadFoldersList(this.UserFoldersFilepath);
                Folders.AddRange(folderDialog.FileNames);

                foreach(string folderPath in folderDialog.FileNames)
                    ProcessDirectory(folderPath, true);

                IOClass.SaveFilesList(Files, this.UserFilesFilepath);
                listBoxFolders.ItemsSource = Folders;
                listBoxFiles.ItemsSource = Files;
                IOClass.SaveFoldersList(Folders, this.UserFoldersFilepath);
            }
        }

        /// <summary>
        /// Deletes file paths that are no longer protected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteFilesBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = listBoxFiles.SelectedItem.ToString();
            Files.Remove(selectedItem);
            IOClass.SaveFilesList(Files, @"C:\temp\files.json");
            listBoxFiles.ItemsSource = Files;
        }

        /// <summary>
        /// Deletes folder paths that are no longer protected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteFoldersBtn_Click(object sender, RoutedEventArgs e)
        {
            string selectedItem = listBoxFolders.SelectedItem.ToString();
            ProcessDirectory(selectedItem, false);
            IOClass.SaveFilesList(Files, this.UserFilesFilepath);
            Folders.Remove(selectedItem);
            IOClass.SaveFoldersList(Folders, this.UserFoldersFilepath);
            listBoxFiles.ItemsSource = Files;
            listBoxFolders.ItemsSource = Folders;
        }

        /// <summary>
        /// Minimizes window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (this.WindowState == WindowState.Minimized)
            {
                this.WindowState = WindowState.Normal;
            }
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (ConnectedTrustedDevices.Count > 0)
            {
                MessageBox.Show("You need to eject your trusted key before exiting the program.", "Files are decrypted!", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Application.Current.Shutdown();
            }
        }

        #endregion

        #region List Boxes Binding Methods

        /// <summary>
        /// Binds device data to list boxes
        /// </summary>
        private void bindDeviceListBoxes()
        {
            List<string> connectedDeviceNames = new List<string>();
            List<string> connectedTrustedDeviceNames = new List<string>();

            if (ConnectedDevices.Count > 0)
            {
                bool connectedDeviceIsATrustedDevice;
                foreach (var connectedDevice in ConnectedDevices)
                {
                    connectedDeviceIsATrustedDevice = false;
                    foreach (var connectedTrustedDevice in ConnectedTrustedDevices)
                    {
                        if (connectedTrustedDevice.SerialNumber.Equals(connectedDevice.SerialNumber))
                        {
                            connectedDeviceIsATrustedDevice = true;
                        }
                    }

                    if (!connectedDeviceIsATrustedDevice)
                    {
                        connectedDeviceNames.Add(connectedDevice.Model + " : " + connectedDevice.VolumeName);
                    }
                }

                if (connectedDeviceNames.Count < 1)
                {
                    listBoxTrustedDevices.Visibility = Visibility.Hidden;
                    listBoxConnectedDevices.Visibility = Visibility.Hidden;
                    submitButton.IsEnabled = false;
                }
                else
                {
                    listBoxConnectedDevices.ItemsSource = connectedDeviceNames;
                    listBoxConnectedDevices.Visibility = Visibility.Visible;
                    submitButton.IsEnabled = true;
                }
            }
            else
            {
                listBoxTrustedDevices.Visibility = Visibility.Hidden;
                listBoxConnectedDevices.Visibility = Visibility.Hidden;
                submitButton.IsEnabled = false;
            }

            if (ConnectedTrustedDevices.Count > 0)
            {
                foreach (var device in ConnectedTrustedDevices)
                {
                    connectedTrustedDeviceNames.Add(device.Model + " : " + device.VolumeName);
                }

                listBoxTrustedDevices.ItemsSource = connectedTrustedDeviceNames;
                listBoxTrustedDevices.Visibility = Visibility.Visible;
                deleteTrustedDeviceBtn.Visibility = Visibility.Visible;
                statusLabel.Visibility = Visibility.Hidden;
            }
            else
            {
                listBoxTrustedDevices.Visibility = Visibility.Hidden;
                deleteTrustedDeviceBtn.Visibility = Visibility.Hidden;
                deleteTrustedDeviceBtn.IsEnabled = false;
                statusLabel.Content = "No trusted devices found";
                statusLabel.Foreground = Brushes.Red;
                statusLabel.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Binds file paths data to list boxes
        /// </summary>
        private void bindFilesListBox()
        {
            Files = IOClass.ReadFilesList(UserFilesFilepath);
            EncryptedFiles = IOClass.ReadFilesList(this.UserEncryptedFilesFilepath);

            if (Files.Count > 0)
            {
                listBoxFiles.ItemsSource = Files;
            }
            else if (EncryptedFiles.Count >= 0)
            {
                listBoxFiles.ItemsSource = EncryptedFiles;
            }
        }

        /// <summary>
        /// Binds folder paths data to list boxes
        /// </summary>
        private void bindFoldersListBox()
        {
            Folders = IOClass.ReadFoldersList(this.UserFoldersFilepath);
            if (Folders.Count > 0)
            {
                listBoxFolders.ItemsSource = Folders;
            }
        }

        #endregion

        #region Device Management Methods

        /// <summary>
        /// Sets private members with connected devices data
        /// </summary>
        private void UpdateConnectedDevices()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();

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
                            string path = volumeLetter + @":\USBLockerPrivateKey.xml";

                            //string Manufacturer = (string)diskDrive["Manufacturer"];
                            //string MediaType = (string)diskDrive["MediaType"];
                            //long FreeSpace = Convert.ToInt64(volume["FreeSpace"]);

                            devices.Add(new DeviceInfo(volumeLetter.ToString(), volumeName, model, serialNumber, size, path));
                        }
                    }
                }
            }

            if (devices.Equals(ConnectedDevices))
            {
                DeviceListChanged = false;
            }
            else
            {
                DeviceListChanged = true;
            }
            
            ConnectedDevices = devices;
        }

        /// <summary>
        /// Updates all data about devices and sets authorization status
        /// </summary>
        private void UpdateDevicesStatus()
        {
            TrustedDevices = IOClass.ReadTrustedDevicesList(this.UserKeyDataFilepath);
            UpdateConnectedTrustedDevices();
            bindDeviceListBoxes();
            labelKeysCounter.Content = TrustedDevices.Count;

            if (Files.Count > 0)
            {
                labelFilesCounter.Content = Files.Count;
            }
            else if (EncryptedFiles.Count >= 0)
            {
                labelFilesCounter.Content = EncryptedFiles.Count;
            }

            var uiSyncContext = SynchronizationContext.Current;

            // Decrypt all data and inform a user about authorization status
            if (AuthorizationStatus)
            {   
                DidUserLoggedUnauthorized = false;

                if (EncryptedFiles.Count > 0)
                {
                    // New Task to decrypt all files
                    var decryptionTask = Task.Run(() =>
                    {
                        string password = DataCryptography.DecryptAESKey(LoggedUser.AesKey, RsaPrivateKey);
                        GCHandle gCHandle = GCHandle.Alloc(password, GCHandleType.Pinned);
                        foreach (string encryptedFilePath in EncryptedFiles)
                        {
                            string filePath = DataCryptography.FileDecrypt(encryptedFilePath, password);
                            Files.Add(filePath);
                        }
                        DataCryptography.ZeroMemory(gCHandle.AddrOfPinnedObject(), password.Length * 2);
                        gCHandle.Free();
                    });
                    decryptionTask.Wait();
                    EncryptedFiles.Clear();
                    IOClass.SaveFilesList(Files, this.UserFilesFilepath);
                    IOClass.SaveFilesList(EncryptedFiles, this.UserEncryptedFilesFilepath);
                }

                uiSyncContext.Post((s) =>
                {
                    labelStatus.Foreground = new SolidColorBrush(Colors.Gold);
                    labelStatus.Content = "Authorized";
                    bindFilesListBox();
                }, null);
            }
            else // Encrypt all data and inform a user about authorization status
            {
                // Prevents from double encryption if user logs in unauthorized
                if (!DidUserLoggedUnauthorized && Files.Count > 0)
                {
                    // New Task to encrypt all files
                    var encryptionTask = Task.Run(() =>
                    {
                        string password = DataCryptography.DecryptAESKey(LoggedUser.AesKey, RsaPrivateKey);
                        GCHandle gCHandle = GCHandle.Alloc(password, GCHandleType.Pinned);

                        foreach (string filePath in Files)
                        {
                            string encryptedFilePath = DataCryptography.FileEncrypt(filePath, password);
                            EncryptedFiles.Add(encryptedFilePath);
                        }

                        DataCryptography.ZeroMemory(gCHandle.AddrOfPinnedObject(), password.Length * 2);
                        gCHandle.Free();
                    });
                    encryptionTask.Wait();
                    Files.Clear();
                    IOClass.SaveFilesList(Files, this.UserFilesFilepath);
                    IOClass.SaveFilesList(EncryptedFiles, this.UserEncryptedFilesFilepath);
                }

                uiSyncContext.Post((s) =>
                {
                    labelStatus.Foreground = new SolidColorBrush(Colors.Red);
                    labelStatus.Content = "Unauthorized";
                    bindFilesListBox();
                }, null);

            }
        }

        /// <summary>
        /// Updates data about connected trusted devices
        /// </summary>
        void UpdateConnectedTrustedDevices()
        {
            List<DeviceInfo> devices = new List<DeviceInfo>();
            foreach (var trustedDevice in TrustedDevices)
            {
                foreach (var connectedDevice in ConnectedDevices)
                {
                    if (trustedDevice.SerialNumber.Equals(connectedDevice.SerialNumber))
                    {
                        devices.Add(trustedDevice);
                    }
                }
            }
            ConnectedTrustedDevices = devices;
        }

        /// <summary>
        /// Creates an authentication key from selected device and saves it to the list.
        /// Adds a private key to device and public key to user data.
        /// </summary>
        /// <param name="deviceData"></param>
        /// <returns>Returns true if procedure went well</returns>
        bool addTrustedDevice(string deviceData)
        {
            // Temporary limit of trusted devices due to lack of multi-private-key system
            if (TrustedDevices.Count.Equals(0)) 
            {
                string[] deviceDataArray = deviceData.Split(':');
                string deviceModel = deviceDataArray[0].Trim();
                string deviceName = deviceDataArray[1].Trim();

                foreach (var device in ConnectedDevices)
                {
                    if (device.VolumeName.Equals(deviceName) && device.Model.Equals(deviceModel))
                    {
                        TrustedDevices.Add(device);
                        string publicKeyString, privateKeyString;
                        (publicKeyString, privateKeyString) = DataCryptography.GenerateRsaKeys();
                        string aesKey = LoggedUser.GetAesKey();
                        string encryptedAesKey = DataCryptography.EncryptAESKey(aesKey, publicKeyString);

                        if (IOClass.SaveTrustedDevicesList(TrustedDevices, this.UserKeyDataFilepath) &&
                            IOClass.SavePrivateKeyOnDevice(device.Path, privateKeyString))
                        {
                            LoggedUser.SetPublicKeyXmlString(publicKeyString);
                            LoggedUser.setAesKey(encryptedAesKey);
                            IOClass.UpdateUser(LoggedUser);
                            break;
                        }
                        else
                            MessageBox.Show("Couldn't create an authentication key.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                return true;
            }
            else
            {
                MessageBox.Show("You already have your trusted device. Couldn't create another one.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
        }

        /// <summary>
        /// Deletes an authentication key from the list
        /// </summary>
        /// <param name="deviceData"></param>
        /// <returns></returns>
        bool deleteTrustedDevice(string deviceData)
        {
            string[] deviceDataArray = deviceData.Split(':');
            string deviceModel = deviceDataArray[0].Trim();
            string deviceName = deviceDataArray[1].Trim();

            foreach (var device in TrustedDevices)
            {
                if (device.VolumeName.Equals(deviceName) && device.Model.Equals(deviceModel))
                {
                    TrustedDevices.Remove(device);
                    if(IOClass.RemovePrivateKeyFromDevice(device.Path) && 
                       IOClass.SaveTrustedDevicesList(TrustedDevices, this.UserKeyDataFilepath))
                    {
                        LoggedUser.SetPublicKeyXmlString(null);
                        LoggedUser.setAesKey(null);
                        IOClass.UpdateUser(LoggedUser);
                        return true;
                    }
                }
            }
            return false;
        }

        #endregion

        #region File Processing

        // Process all files in the directory passed in, recurse on any directories 
        // that are found, and process the files they contain.
        public void ProcessDirectory(string targetDirectory, bool addOrDelete)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = System.IO.Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
                if (addOrDelete)
                    AddDirectoryPaths(fileName);
                else
                    DeleteDirectoryPaths(fileName);

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = System.IO.Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
                ProcessDirectory(subdirectory, addOrDelete);
        }

        public void AddDirectoryPaths(string path)
        {
            Files.Add(path);
        }

        public void DeleteDirectoryPaths(string path)
        {
            Files.Remove(path);
        }

        #endregion

        private void comboBoxAutoStart_Checked(object sender, RoutedEventArgs e)
        {
            if(checkBoxAutoStart.IsChecked ?? false)
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                string str = System.Reflection.Assembly.GetExecutingAssembly().Location;
                key.SetValue("Paak", str);
            }
            else
            {
                Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
                string str = System.Reflection.Assembly.GetExecutingAssembly().Location;
                key.SetValue("Paak", str);
            }
            
        }

        private void textBoxSecurityAnswer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxSecurityAnswer.Text.Equals("Security answer"))
            {
                textBoxSecurityAnswer.Text = string.Empty;
                textBoxSecurityAnswer.Opacity = 1;
            }
        }

        private void textBoxSecurityAnswer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxSecurityAnswer.Text.Equals(string.Empty))
            {
                textBoxSecurityAnswer.Text = "Security answer";
                textBoxSecurityAnswer.Opacity = 0.5;
            }
        }

        private void textBoxRecoveryPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxRecoveryPassword.Password.Equals("Password"))
            {
                textBoxRecoveryPassword.Password = string.Empty;
                textBoxRecoveryPassword.Opacity = 1;
            }
        }

        private void textBoxRecoveryPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxRecoveryPassword.Password.Equals(string.Empty))
            {
                textBoxRecoveryPassword.Password = "Password";
                textBoxRecoveryPassword.Opacity = 0.5;
            }
        }

        private void btnRecoverFiles_Click(object sender, RoutedEventArgs e)
        {
            string securityAnswer = textBoxSecurityAnswer.Text.ToLower();
            string password = textBoxRecoveryPassword.Password;

            if (EncryptedFiles.Count.Equals(0))
            {
                MessageBox.Show("You have no files to recover.", "No encrypted files found", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                if (DataCryptography.SHA512(securityAnswer).Equals(LoggedUser.GetAnswer()) && DataCryptography.SHA512(password).Equals(LoggedUser.GetPassword()))
                {
                    MessageBoxResult result = MessageBox.Show("Do you want to recover your files? All your program settings and keys will be deleted.", "Files recovery system", MessageBoxButton.YesNo, MessageBoxImage.Question);

                    if (result.Equals(MessageBoxResult.Yes))
                    {
                        string aesKey = DataCryptography.SHA512(DataCryptography.GenerateAesKey(this.Username,
                                                                                                password,
                                                                                                LoggedUser.GetQuestion(),
                                                                                                securityAnswer));

                        List<string> tempEncryptedFiles = new List<string>(EncryptedFiles);
                        EncryptedFiles.Clear();
                        Files.Clear();
                        Folders.Clear();
                        TrustedDevices.Clear();

                        var decryptionTask = Task.Run(() =>
                        {
                            foreach (string encryptedFilePath in tempEncryptedFiles)
                            {
                                string filePath = DataCryptography.FileDecrypt(encryptedFilePath, aesKey);
                            }
                        });
                        decryptionTask.Wait();

                        LoggedUser.SetPublicKeyXmlString(String.Empty);
                        LoggedUser.setAesKey(aesKey);

                        IOClass.SaveFilesList(Files, this.UserFilesFilepath);
                        IOClass.SaveFilesList(EncryptedFiles, this.UserEncryptedFilesFilepath);
                        IOClass.SaveFoldersList(Folders, this.UserFoldersFilepath);
                        IOClass.SaveTrustedDevicesList(TrustedDevices, this.UserKeyDataFilepath);
                        IOClass.UpdateUser(LoggedUser);
                        

                        bindFilesListBox();
                        bindFoldersListBox();

                        MessageBox.Show("Your files are decrypted now.", "Files recovery system", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Security answer or password incorrect!", "Files recovery system", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }
    }
}
