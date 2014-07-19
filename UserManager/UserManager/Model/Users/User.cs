using System;
//using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel;

namespace UserManager.Model.Users
{
    public class User : IDataErrorInfo
    {
        #region Properties
        public String Username { get; set; }
        public String Password { get; set; }
        public String Realname { get; set; }
        public bool IsValid
        {
            get
            {
                if (!String.IsNullOrEmpty(GetUsernameValidationError()) | 
                    !String.IsNullOrEmpty(GetPasswordValidationError()) |
                    !String.IsNullOrEmpty(GetRealnameValidationError()))
                    return false;

                return true;
            }
        }
        #endregion

        #region Constructors
        public User()
        {
            Username = "";
            Password = "";
            Realname = "";
        }

        public User(String Username, String Password, String Realname = "")
        {
            this.Username = Username;
            this.Password = Password;
            this.Realname = Realname;
        }

        public User(String Username, byte[] Password, String Realname = "")
        {
            this.Username = Username;
            this.Password = Encoding.UTF8.GetString(Password);
            this.Realname = Realname;
        }
        #endregion

        #region Helpers
        public bool IsNullOrEmpty()
        {
            if (String.IsNullOrEmpty(Username) | String.IsNullOrEmpty(Password) | String.IsNullOrEmpty(Realname))
                return true;
            else
                return false;
        }

        public string GetUsernameValidationError()
        {
            if (Regex.IsMatch(Username, @"^[a-z0-9_-]{3,15}$"))
                return String.Empty;
            else
                return "Invalid Username. Use 3 to 15 characters with lower case letters, numbers, underscore and dash.";
        }

        public string GetRealnameValidationError()
        {
            if (Regex.IsMatch(Realname, @"^[a-zA-Z ]{1,}$"))
                return String.Empty;
            else
                return "Invalid Realname. Only upper or lower case letters.";
        }

        public string GetPasswordValidationError()
        {
            if (!String.IsNullOrEmpty(Password))
                return String.Empty;
            else
                return "Invalid empty password.";
        }

        #endregion

        #region IDataErrorInfo
        string IDataErrorInfo.Error
        {
            get { return String.Empty; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get 
            {
                switch (propertyName)
                {
                    case "Username":
                        return GetUsernameValidationError();
                    case "Realname":
                        return GetRealnameValidationError();
                    default:
                        return String.Empty;
                }
            }
        }
        #endregion
    }
}
