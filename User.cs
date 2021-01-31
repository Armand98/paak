namespace USB_Locker
{
    class User
    {
        private int UserID { get; set; }
        private string FirstName { get; set; }
        private string LastName { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Birthday { get; set; }
        private string Question { get; set; }
        private string Answer { get; set; }
        private int KeysQuantity { get; set; }
        private string PublicKeyXml { get; set; }
        private string AesKey { get; set; }

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

        public void SetAesKey(string key)
        {
            this.AesKey = key;
        }
    }
}
