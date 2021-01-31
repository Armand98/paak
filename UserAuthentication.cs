using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace USB_Locker
{
    /// <summary>
    /// Provides all authorization methods
    /// </summary>
    static class UserAuthentication
    {
        /// <summary>
        /// Checks user's credentials and allows to log in
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns>True - if credentials were ok, 
        /// False - if credentials were wrong</returns>
        public static bool Login(string login, string password)
        {
            List<User> usersList = IOClass.ReadUsersList();
            string loginHash = DataCryptography.SHA512(login);
            string passwordHash = DataCryptography.SHA512(password);

            foreach (User user in usersList)
            {
                if(user.GetUsername().Equals(loginHash))
                {
                    if(user.GetPassword().Equals(passwordHash))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Register new user and saves all data in json file
        /// </summary>
        /// <param name="user"></param>
        /// <returns>0 - if registration went successful, 
        /// 1 - if some error occured, 
        /// 2 - if username is already used</returns>
        public static int Register(User user)
        {
            string hashedUsername = DataCryptography.SHA512(user.GetUsername());
            if (IsUsernameNotTaken(hashedUsername))
            {
                User userHashedData = new User(DataCryptography.SHA512(user.GetFirstName()),
                                                                       DataCryptography.SHA512(user.GetLastName()),
                                                                       hashedUsername,
                                                                       DataCryptography.SHA512(user.GetPassword()),
                                                                       DataCryptography.SHA512(user.GetBirthday()),
                                                                       user.GetQuestion(),
                                                                       DataCryptography.SHA512(user.GetAnswer().ToLower()),
                                                                       DataCryptography.SHA512(DataCryptography.GenerateAesKey(user.GetUsername(),
                                                                                                                               user.GetPassword(),
                                                                                                                               user.GetQuestion(),
                                                                                                                               user.GetAnswer().ToLower())));

                if (IOClass.SaveNewUser(userHashedData, user.GetUsername()))
                    return 0;
                else
                    return 1;
            }
            return 2;
        }

        /// <summary>
        /// Checks if passed username is already used by another user
        /// </summary>
        /// <param name="username">Users username passed from register form</param>
        /// <returns>True - if username is not used, 
        /// False - if username is used</returns>
        public static bool IsUsernameNotTaken(string username)
        {
            List<User> usersList = IOClass.ReadUsersList();
            
            foreach(User user in usersList)
            {
                if(user.GetUsername().Equals(username))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Provides register data validation
        /// </summary>
        /// <param name="firstName">User's first name</param>
        /// <param name="lastName">User's last name</param>
        /// <param name="username">User's username</param>
        /// <param name="password">User's password</param>
        /// <param name="birthday">User's birthday</param>
        /// <param name="question">User's security question</param>
        /// <param name="answer">User's security answer</param>
        /// <returns>1 - if some parameters were empty, 
        /// 2 - if username length is too short, 
        /// 3 - if password length is too short or is too simple, 
        /// 4 - if password contains white spaces,
        /// 5 - if date format is wrong</returns>
        public static int ValidateRegisterData(string firstName, string lastName, string username, string password, string birthday, string question, string answer)
        {
            if (firstName.Equals("First name"))
                firstName = string.Empty;

            if (lastName.Equals("Last name"))
                lastName = string.Empty;

            if (username.Equals("Username"))
                username = string.Empty;

            if (password.Equals("Password"))
                password = string.Empty;

            if (birthday.Equals("Birthday: day-month-year"))
                birthday = string.Empty;

            if (answer.Equals("Answer"))
                answer = string.Empty;

            if (firstName.Length.Equals(0) || lastName.Length.Equals(0) || username.Length.Equals(0) || password.Length.Equals(0) || birthday.Length.Equals(0) || question.Length.Equals(0) || answer.Length.Equals(0))
                return 1;

            if (username.Length < 3)
                return 2;

            if (password.Length < 8)
                return 3;

            if (!password.Any(char.IsUpper) || !password.Any(char.IsLower) || !password.Any(char.IsDigit))
                return 3;

            if (password.Any(char.IsWhiteSpace))
                return 4;

            // Regex checks date format: day-month-year
            Regex rx = new Regex(@"^([0-2][0-9]|(3)[0-1])(\-)(((0)[0-9])|((1)[0-2]))(\-)\d{4}$");
            Match match = rx.Match(birthday);

            if(!match.Success)
                return 5;

            return 0;
        }
    }
}
