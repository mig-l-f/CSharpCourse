using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using NUnit.Framework;
using UserManager.Model.Encryption;
using UserManager.Model.Users;
using UserManager.ViewModel;

namespace UserManagerTest
{
    [TestFixture]
    public class UserRepositoryTest
    {
        [Test]
        public void addNewUserTest()
        {
            UserRepository target = new UserRepository();
            string username = "muse";
            string name = "Miguel";
            string passHash = "a";
            User user = new User(username, passHash, name);
            Assert.IsTrue(target.AddUser(user), "User Not Added");
            Assert.AreEqual((int)1, target.users.Count);
        }

        [Test]
        public void addExistingUserFails()
        {
            UserRepository target = new UserRepository();
            string username = "muse";
            string name = "Miguel";
            string passHash = "a";
            User user1 = new User(username, passHash, name);
            User user2 = new User(username, passHash, name);
            Assert.IsTrue(target.AddUser(user1), "Should have added 1st user");
            Assert.IsFalse(target.AddUser(user2), "Should have failed to add existing user");
            Assert.AreEqual((int)1, target.users.Count);
        }

        [Test]
        public void findUserTest()
        {
            UserRepository target = new UserRepository();
            string username = "muse";
            string name = "Miguel";
            string passHash = "a";
            User user1 = new User(username, passHash, name);
            username = "muse2";
            User user2 = new User(username, passHash, name);
            target.AddUser(user1);
            target.AddUser(user2);
            Assert.AreEqual(2, target.users.Count, "Failed to add users");
            User selectedUser = target.GetUser(username);
            Assert.AreEqual(selectedUser.Username, username);
        }

        [Test]
        public void findNonExistingUserFails()
        {
            UserRepository target = new UserRepository();
            string username = "muse";
            string name = "Miguel";
            string passHash = "a";
            User user1 = new User(username, passHash, name);
            username = "muse2";
            User user2 = new User(username, passHash, name);
            target.AddUser(user1);
            target.AddUser(user2);
            Assert.AreEqual(2, target.users.Count, "Failed to add users");
            User selectedUser = target.GetUser("nonexistent");
            Assert.IsTrue(selectedUser.IsNullOrEmpty(), "User should be empty");
        }
        
    }
}
