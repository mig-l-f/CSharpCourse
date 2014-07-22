using System;
using UserManager.Model;
using UserManager.Model.Users;
using UserManager.Model.Encryption;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Input;
//using System.Threading.Tasks;

namespace UserManager.ViewModel
{
    public class UserManagerViewModel : IDataErrorInfo, INotifyPropertyChanged
    {
        #region Fields
        private UserRepository repository_;
        private User currentUser_;
        private PasswordHasher hasher_;
        private string error;
        private bool isAuthenticated_;
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
                NotifyPropertyChanged("Username");
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
                NotifyPropertyChanged("Password");
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
                NotifyPropertyChanged("Realname");
            }
        }

        public ObservableCollection<User> Users
        {
            get
            {
                return repository_.users;
            }            
        }

        public ICommand AddUserCommand 
        {
            get { return new RelayCommand(param => this.AddUser()); } 
        }

        public ICommand CheckUserCommand
        {
            get { return new RelayCommand(param => this.IsUserValid()); }
        }

        public Boolean IsAuthenticated 
        {
            get
            {
                return isAuthenticated_;
            }
            set 
            {
                isAuthenticated_ = value;
                NotifyPropertyChanged("IsAuthenticated"); 
            }
        }

        #endregion

        public void AddUser()
        {
            currentUser_.Password = hasher_.GetHash(currentUser_.Password, currentUser_.Username);

            if (repository_.AddUser(currentUser_))
            {
                ClearCurrentUserAddNewOne();
                NotifyPropertyChanged("Users");
            }
                
               // currentUser_ = new User(); // clear the current user, so a new one can be inserted

        }

        public void IsUserValid()
        {
            User selectedUser = repository_.GetUser(Username);
            if (selectedUser.IsNullOrEmpty())
            {
                error = "Unknown username";
                IsAuthenticated = false;
                Console.WriteLine("Failed User Name");
            }
            else if (!hasher_.VerifyHash(Password, selectedUser.Password, Username))
            {
                error = "Passwords do not match";
                IsAuthenticated = false;
                Console.WriteLine("Failed Password");
            }
            else 
            {
                error = String.Empty;
                IsAuthenticated = true;
                Console.WriteLine("User Authenticated");
            }
            NotifyPropertyChanged("IsAutenticated");
        }

        private void ClearCurrentUserAddNewOne()
        {
            currentUser_ = new User();
            IsAuthenticated = false;
            NotifyPropertyChanged("Username");
            NotifyPropertyChanged("Password");
            NotifyPropertyChanged("Realname");
            NotifyPropertyChanged("IsAuthenticated");
        }

        #region IDataErrorInfo Members
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


        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }

}
