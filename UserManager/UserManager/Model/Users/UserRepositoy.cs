using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using UserManager.Model.Encryption;

namespace UserManager.Model.Users
{
    public class UserRepository
    {
        #region Fields
        readonly ObservableCollection<User> users_ = new ObservableCollection<User>();
        #endregion

        #region Properties
        public ObservableCollection<User> users 
        { 
            get 
            {
                return users_;
            }            
        }
        #endregion

        #region Constructors
        public UserRepository() { }
        
        #endregion

        public bool AddUser(User user)
        {
            if (!user.IsValid)
                return false;

            string name = user.Username;
            if (users.Any(u => u.Username == name))
                return false;

            users.Add(user);
            return true;
        }

        public User GetUser(string username)
        {
              User selectedUser = (from u in users
                                   where String.Compare(u.Username, username) == 0
                                   select u).FirstOrDefault();
              if (selectedUser != null)
                  return selectedUser;
              else
                  return new User();

        }
    }
}
