using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using NUnit.Framework;
using UserManager.Model.Users;

namespace UserManagerTest
{
    [TestFixture]
    public class UserTest
    {
        [Test]
        public void createValidUser()
        {
            string username = "usernamevalid";            
            string realname = "Nome Valido";
            string passHash = "a";
            User target = new User(username, passHash, realname);
            Assert.IsTrue(target.IsValid, "User should be valid.");
        }        

        [Test]
        public void createUserWithInvalidUsername()
        {
            string username = "££@23fgf__";
            string realname = "Nome valido";
            string passHash = "a";
            User target = new User(username, passHash, realname);
            Assert.IsFalse(target.IsValid, "Username should be invalid");
        }

        [Test]
        public void passwordHashCannotBeEmpty()
        {
            string username = "usernamevalid";
            string realname = "Nome Valido";
            User target = new User(username, "", realname);
            Assert.IsFalse(target.IsValid, "Password should be invalid");
        }

        [Test]
        public void createUserWithInvalidRealname()
        {
            string username = "fge234";
            string realname = "HJH_GHG 545";
            string passHash = "a";
            User target = new User(username, passHash, realname);
            Assert.IsFalse(target.IsValid, "Realname should be invalid");
        }
    }
}
