using System;
using UserManager.Model.Users;
using UserManager.Model.Encryption;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.ComponentModel;
//using System.Threading.Tasks;

namespace UserManager.ViewModel
{
    public class UserManagerViewModel : IDataErrorInfo
    {
        #region Fields
        private UserRepository repository_;
        private User currentUser_;
        private PasswordHasher hasher_;
        private string error;
        #endregion

        #region Constructors
        public UserManagerViewModel(User user, UserRepository repository, PasswordHasher hasher)
        {
            this.currentUser_ = user;
            this.repository_ = repository;
            this.hasher_ = hasher;
            error = String.Empty;
        }
        #endregion

        #region Properties

        public string Username
        {
            get
            {
                return currentUser_.Username;
            }
            set
            {
                currentUser_.Username = value;
            }
        }

        public string Password
        {
            get
            {
                return currentUser_.Password;
            }
            set
            {
                currentUser_.Password = value;
            }
        }

        public string Realname
        {
            get
            {
                return currentUser_.Realname;
            }
            set
            {
                currentUser_.Realname = value;
            }
        }

        public ObservableCollection<User> Users
        {
            get
            {
                return repository_.users;
            }            
        }

        #endregion

        public void AddUser()
        {
            currentUser_.Password = hasher_.GetHash(currentUser_.Password, currentUser_.Username);

            if (repository_.AddUser(currentUser_))
                currentUser_ = new User(); // clear the current user, so a new one can be inserted

        }

        public bool IsUserValid()
        {
            User selectedUser = repository_.GetUser(Username);
            if (selectedUser.IsNullOrEmpty())
            {
                error = "Unknown username";
                return false;
            }
            if (!hasher_.VerifyHash(Password, selectedUser.Password, Username))
            {
                error = "Passwords do not match";
                return false;
            }

            error = String.Empty;
            return true;
        }

        #region IDataErrorInfo
        string IDataErrorInfo.Error
        {
            get { return error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get 
            {
                return (currentUser_ as IDataErrorInfo)[propertyName];
            }
        }
        #endregion
    }

}
