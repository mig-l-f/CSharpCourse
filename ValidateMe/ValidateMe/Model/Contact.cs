using System;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace ValidateMe
{
    public class Contact : IDataErrorInfo
    {
        private String _name ="";
        private String _phone = "";
        private String _email = "";

        #region Properties
        public String Name 
        {
            get 
            {
                return _name;
            }
            set
            {
                _name = value;
            } 
        }
        public String Telephone 
        {
            get
            {
                return _phone;
            }
            set
            {
                _phone = value;
            }
        }
        public String Email 
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
            }
        }
        #endregion

        #region IDataErrorInfo Members
        string IDataErrorInfo.Error
        {
            get
            { 
                return null;
            }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get 
            {
                string error = null;
                switch (propertyName)
                {
                    case "Name":
                        error = ValidateName();
                        break; 
                    case "Telephone":
                        error = ValidatePhoneNumber();
                        break;
                    case "Email":
                        error = ValidateEmail();
                        break;
                }
                return error;
            }
        }
        #endregion

        private String ValidateName()
        {
            if (!Regex.IsMatch(Name, @"^[A-Za-z][A-Za-z ]*[A-Za-z]$"))
            {
                return @"Invalid Name: Only letters or Spaces.";
            }
            return null;
        }
        private String ValidatePhoneNumber()
        {
            if (!Regex.IsMatch(Telephone, @"^\d{3}-\d{4}$"))
            {
                return @"Invalid Phone: Format XXX-XXXX";
            }
            return null;
        }
        private String ValidateEmail()
        {
            if (!Regex.IsMatch(Email, @"^[A-Za-z0-9_.]+@[A-Za-z0-9]+\.[A-Za-z]+$"))
            {
                return @"Invalid Email: [a-z][0-9][._]@[a-z][0-9].[a-z]";
            }
            return null;
        }
    }
}
