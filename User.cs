namespace USB_Locker
{
    class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Birthday { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
        public int KeysQuantity { get; set; }
        public string PublicKeyXml { get; set; }
        public string AesKey { get; set; }

        public User(string firstName, string lastName, string username, string password, string birthday, string question, string answer, string aesKey)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Username = username;
            this.Password = password;
            this.Birthday = birthday;
            this.Question = question;
            this.Answer = answer;
            this.KeysQuantity = 0;
            this.PublicKeyXml = null;
            this.AesKey = aesKey;
        }

        public void SetID(int id)
        {
            this.UserID = id;
        }

        public int GetID()
        {
            return this.UserID;
        }

        public string GetFirstName()
        {
            return FirstName;
        }

        public string GetLastName()
        {
            return LastName;
        }

        public string GetUsername()
        {
            return Username;
        }

        public void SetUsername(string username)
        {
            this.Username = username;
        }

        public string GetPassword()
        {
            return Password;
        }

        public string GetBirthday()
        {
            return Birthday;
        }

        public string GetQuestion()
        {
            return Question;
        }

        public string GetAnswer()
        {
            return Answer;
        }

        public int GetKeysQuantity()
        {
            return this.KeysQuantity;
        }

        public void SetKeysQuantity(int quantity)
        {
            this.KeysQuantity = quantity;
        }

        public void SetPublicKeyXmlString(string PublicKeyXml)
        {
            this.PublicKeyXml = PublicKeyXml;
        }

        public string GetPublicKeyXmlString()
        {
            return PublicKeyXml;
        }

        public string GetAesKey()
        {
            return this.AesKey;
        }

        public void setAesKey(string key)
        {
            this.AesKey = key;
        }
    }
}
