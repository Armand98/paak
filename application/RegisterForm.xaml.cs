using System.Windows;
using System.Windows.Input;

namespace USB_Locker
{
    /// <summary>
    /// Logika interakcji dla klasy RegisterForm.xaml
    /// </summary>
    public partial class RegisterForm : Window
    {
        #region Constructor

        public RegisterForm()
        {
            InitializeComponent();
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
                DragMove();
        }

        /// <summary>
        /// Provides data validation and creates an account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCreateAnAccount_Click(object sender, RoutedEventArgs e)
        {
            string firstName, lastName, username, password, birthday, question, answer;

            firstName = textBoxFirstName.Text;
            lastName = textBoxLastName.Text;
            username = textBoxUsername.Text;
            password = textBoxPassword.Password;
            birthday = textBoxBirthday.Text;
            question = comboBoxQuestion.Text;
            answer = textBoxAnswer.Text;

            switch(UserAuthentication.ValidateRegisterData(firstName, lastName, username, password, birthday, question, answer))
            {
                case 1:
                    MessageBox.Show("You need to fill in a form to create an account.", "Wrong register data", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case 2:
                    MessageBox.Show("Your username must contain at least 3 characters.", "Your username is too short", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case 3:
                    MessageBox.Show("Your password should be at least 8 characters long, composed of both lowercase and uppercase letters and digits.", 
                                    "Your password is too weak", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case 4:
                    MessageBox.Show("Your password can not contain white spaces.", "Illegal characters", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;

                case 5:
                    MessageBox.Show("Your birthday date should be like: 15-05-1990", "Wrong birthday format", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;


                case 0:
                    {
                        User user = new User(firstName, lastName, username, password, birthday, question, answer, "");
                        switch (UserAuthentication.Register(user))
                        {
                            case 0:
                                {
                                    MessageBox.Show("Your account has been successfully created. You can log in with your credentials.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                                    logonScreen logonScreen = new logonScreen();
                                    logonScreen.Show();
                                    Close();
                                }
                                break;

                            case 1:
                                {
                                    MessageBox.Show("Account creation failed.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                }
                                break;

                            case 2:
                                {
                                    MessageBox.Show("This username is already used.", "Invalid username", MessageBoxButton.OK, MessageBoxImage.Warning);
                                }
                                break;
                        }
                    }
                    break;
            }
        }

        /// <summary>
        /// Closes the window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            logonScreen logonScreen = new logonScreen();
            logonScreen.Show();
            Close();
        }

        #region Placeholder effect

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFirstName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxFirstName.Text.Equals("First name"))
            {
                textBoxFirstName.Text = string.Empty;
                textBoxFirstName.Opacity = 1;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxFirstName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxFirstName.Text.Equals(string.Empty))
            {
                textBoxFirstName.Text = "First name";
                textBoxFirstName.Opacity = 1;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxLastName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxLastName.Text.Equals("Last name"))
            {
                textBoxLastName.Text = string.Empty;
                textBoxLastName.Opacity = 1;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxLastName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxLastName.Text.Equals(string.Empty))
            {
                textBoxLastName.Text = "Last name";
                textBoxLastName.Opacity = 0.5;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUsername_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text.Equals("Username"))
            {
                textBoxUsername.Text = string.Empty;
                textBoxUsername.Opacity = 1;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxUsername_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxUsername.Text.Equals(string.Empty))
            {
                textBoxUsername.Text = "Username";
                textBoxUsername.Opacity = 0.5;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPassword_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Password.Equals("Password"))
            {
                textBoxPassword.Password = string.Empty;
                textBoxPassword.Opacity = 1;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxPassword_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxPassword.Password.Equals(string.Empty))
            {
                textBoxPassword.Password = "Password";
                textBoxPassword.Opacity = 0.5;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxBirthdayDate_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxBirthday.Text.Equals("Birthday: day-month-year"))
            {
                textBoxBirthday.Text = string.Empty;
                textBoxBirthday.Opacity = 1;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxBirthdayDate_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxBirthday.Text.Equals(string.Empty))
            {
                textBoxBirthday.Text = "Birthday: day-month-year";
                textBoxBirthday.Opacity = 0.5;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxAnswer_GotFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxAnswer.Text.Equals("Answer"))
            {
                textBoxAnswer.Text = string.Empty;
                textBoxAnswer.Opacity = 1;
            }
        }

        /// <summary>
        /// Provides placeholder effect
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxAnswer_LostFocus(object sender, RoutedEventArgs e)
        {
            if (textBoxAnswer.Text.Equals(string.Empty))
            {
                textBoxAnswer.Text = "Answer";
                textBoxAnswer.Opacity = 0.5;
            }
        }

        #endregion

        #endregion
    }
}
