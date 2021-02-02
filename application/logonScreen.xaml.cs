using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace USB_Locker
{
    /// <summary>
    /// Logika interakcji dla klasy logonScreen.xaml
    /// </summary>
    public partial class logonScreen : Window
    {
        public logonScreen()
        {
            InitializeComponent();
            IOClass.CreateRootDirectory();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void textBoxUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text.Equals("Username"))
            {
                textBoxUsername.Text = string.Empty;
                textBoxUsername.Opacity = 1;
            }
        }

        private void textBoxUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text.Equals(string.Empty))
            {
                textBoxUsername.Text = "Username";
                textBoxUsername.Opacity = 0.5;
            }
        }

        private void textBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Password.Equals("Password"))
            {
                textBoxPassword.Password = string.Empty;
                textBoxPassword.Opacity = 1;
            }
        }

        private void textBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Password.Equals(string.Empty))
            {
                textBoxPassword.Password = "Password";
                textBoxPassword.Opacity = 0.5;
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string login, password;

            login = textBoxUsername.Text;
            password = textBoxPassword.Password;

            if (login.Equals("Username"))
                login = string.Empty;

            if (password.Equals("Password"))
                password = string.Empty;

            if (UserAuthentication.Login(login, password))
            {
                MainWindow mainWindow = new MainWindow(login);
                mainWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Access denied", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.Show();
            Close();
        }

        private void btnMin_Click(object sender, RoutedEventArgs e)
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
    }
}
