﻿#pragma checksum "..\..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "EA84492A619474C823663BA83D1491245AA09D8B"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.IconPacks;
using MahApps.Metro.IconPacks.Converter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using USB_Locker;


namespace USB_Locker {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 70 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal MahApps.Metro.IconPacks.PackIconMaterial IconLock;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelKeysCounter;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelFilesCounter;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelUsername;
        
        #line default
        #line hidden
        
        
        #line 138 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelStatus;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxConnectedDevices;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button submitButton;
        
        #line default
        #line hidden
        
        
        #line 199 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxTrustedDevices;
        
        #line default
        #line hidden
        
        
        #line 204 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label statusLabel;
        
        #line default
        #line hidden
        
        
        #line 211 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteTrustedDeviceBtn;
        
        #line default
        #line hidden
        
        
        #line 231 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxFiles;
        
        #line default
        #line hidden
        
        
        #line 240 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addFilesBtn;
        
        #line default
        #line hidden
        
        
        #line 247 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteFilesBtn;
        
        #line default
        #line hidden
        
        
        #line 267 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxFolders;
        
        #line default
        #line hidden
        
        
        #line 275 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addFoldersBtn;
        
        #line default
        #line hidden
        
        
        #line 281 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteFoldersBtn;
        
        #line default
        #line hidden
        
        
        #line 303 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelSecurityQuestion;
        
        #line default
        #line hidden
        
        
        #line 331 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox textBoxSecurityAnswer;
        
        #line default
        #line hidden
        
        
        #line 361 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox textBoxRecoveryPassword;
        
        #line default
        #line hidden
        
        
        #line 389 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnRecoverFiles;
        
        #line default
        #line hidden
        
        
        #line 400 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox checkBoxAutoStart;
        
        #line default
        #line hidden
        
        
        #line 414 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnMinimize;
        
        #line default
        #line hidden
        
        
        #line 427 "..\..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnExit;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PAAK;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 12 "..\..\..\..\MainWindow.xaml"
            ((USB_Locker.MainWindow)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.IconLock = ((MahApps.Metro.IconPacks.PackIconMaterial)(target));
            return;
            case 3:
            this.labelKeysCounter = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.labelFilesCounter = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.labelUsername = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.labelStatus = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.listBoxConnectedDevices = ((System.Windows.Controls.ListBox)(target));
            
            #line 181 "..\..\..\..\MainWindow.xaml"
            this.listBoxConnectedDevices.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listBoxConnectedDevices_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.submitButton = ((System.Windows.Controls.Button)(target));
            
            #line 188 "..\..\..\..\MainWindow.xaml"
            this.submitButton.Click += new System.Windows.RoutedEventHandler(this.submitButton_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.listBoxTrustedDevices = ((System.Windows.Controls.ListBox)(target));
            
            #line 202 "..\..\..\..\MainWindow.xaml"
            this.listBoxTrustedDevices.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listBoxTrustedDevices_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            this.statusLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.deleteTrustedDeviceBtn = ((System.Windows.Controls.Button)(target));
            
            #line 215 "..\..\..\..\MainWindow.xaml"
            this.deleteTrustedDeviceBtn.Click += new System.Windows.RoutedEventHandler(this.deleteTrustedDeviceBtn_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.listBoxFiles = ((System.Windows.Controls.ListBox)(target));
            return;
            case 13:
            this.addFilesBtn = ((System.Windows.Controls.Button)(target));
            
            #line 245 "..\..\..\..\MainWindow.xaml"
            this.addFilesBtn.Click += new System.Windows.RoutedEventHandler(this.addFilesBtn_Click);
            
            #line default
            #line hidden
            return;
            case 14:
            this.deleteFilesBtn = ((System.Windows.Controls.Button)(target));
            
            #line 251 "..\..\..\..\MainWindow.xaml"
            this.deleteFilesBtn.Click += new System.Windows.RoutedEventHandler(this.deleteFilesBtn_Click);
            
            #line default
            #line hidden
            return;
            case 15:
            this.listBoxFolders = ((System.Windows.Controls.ListBox)(target));
            return;
            case 16:
            this.addFoldersBtn = ((System.Windows.Controls.Button)(target));
            
            #line 279 "..\..\..\..\MainWindow.xaml"
            this.addFoldersBtn.Click += new System.Windows.RoutedEventHandler(this.addFoldersBtn_Click);
            
            #line default
            #line hidden
            return;
            case 17:
            this.deleteFoldersBtn = ((System.Windows.Controls.Button)(target));
            
            #line 284 "..\..\..\..\MainWindow.xaml"
            this.deleteFoldersBtn.Click += new System.Windows.RoutedEventHandler(this.deleteFoldersBtn_Click);
            
            #line default
            #line hidden
            return;
            case 18:
            this.labelSecurityQuestion = ((System.Windows.Controls.Label)(target));
            return;
            case 19:
            this.textBoxSecurityAnswer = ((System.Windows.Controls.TextBox)(target));
            
            #line 344 "..\..\..\..\MainWindow.xaml"
            this.textBoxSecurityAnswer.GotFocus += new System.Windows.RoutedEventHandler(this.textBoxSecurityAnswer_GotFocus);
            
            #line default
            #line hidden
            
            #line 345 "..\..\..\..\MainWindow.xaml"
            this.textBoxSecurityAnswer.LostFocus += new System.Windows.RoutedEventHandler(this.textBoxSecurityAnswer_LostFocus);
            
            #line default
            #line hidden
            return;
            case 20:
            this.textBoxRecoveryPassword = ((System.Windows.Controls.PasswordBox)(target));
            
            #line 375 "..\..\..\..\MainWindow.xaml"
            this.textBoxRecoveryPassword.GotFocus += new System.Windows.RoutedEventHandler(this.textBoxRecoveryPassword_GotFocus);
            
            #line default
            #line hidden
            
            #line 376 "..\..\..\..\MainWindow.xaml"
            this.textBoxRecoveryPassword.LostFocus += new System.Windows.RoutedEventHandler(this.textBoxRecoveryPassword_LostFocus);
            
            #line default
            #line hidden
            return;
            case 21:
            this.btnRecoverFiles = ((System.Windows.Controls.Button)(target));
            
            #line 392 "..\..\..\..\MainWindow.xaml"
            this.btnRecoverFiles.Click += new System.Windows.RoutedEventHandler(this.btnRecoverFiles_Click);
            
            #line default
            #line hidden
            return;
            case 22:
            this.checkBoxAutoStart = ((System.Windows.Controls.CheckBox)(target));
            
            #line 404 "..\..\..\..\MainWindow.xaml"
            this.checkBoxAutoStart.Checked += new System.Windows.RoutedEventHandler(this.comboBoxAutoStart_Checked);
            
            #line default
            #line hidden
            return;
            case 23:
            this.btnMinimize = ((System.Windows.Controls.Button)(target));
            
            #line 420 "..\..\..\..\MainWindow.xaml"
            this.btnMinimize.Click += new System.Windows.RoutedEventHandler(this.btnMinimize_Click);
            
            #line default
            #line hidden
            return;
            case 24:
            this.btnExit = ((System.Windows.Controls.Button)(target));
            
            #line 433 "..\..\..\..\MainWindow.xaml"
            this.btnExit.Click += new System.Windows.RoutedEventHandler(this.btnExit_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
