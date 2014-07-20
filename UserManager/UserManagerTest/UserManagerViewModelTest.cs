using System;
using System.ComponentModel;
using NUnit.Framework;
using UserManager.ViewModel;
using UserManager.Model.Users;
using UserManager.Model.Encryption;

namespace UserManagerTest
{
    [TestFixture]
    public class UserManagerViewModelTest
    {
        [Test]
        public void addingNewUserUserHashingFunction()
        {
            User user = new User();
            UserRepository repo = new UserRepository();
            PasswordHasher hasherAlgorithm = new HmacSha512Hasher();
            UserManagerViewModel target = new UserManagerViewModel(user, repo, hasherAlgorithm);

            target.Username = "mige";
            target.Password = "teste";
            target.Realname = "Mig";
            target.AddUser();

            Assert.IsTrue(hasherAlgorithm.VerifyHash("teste", target.Users[0].Password, "mige"));
        }

        [Test]
        public void verifyThatAddingUserWithErrorsFails()
        {
            User user = new User();
            UserRepository repo = new UserRepository();
            PasswordHasher hasherAlgorithm = new HmacSha512Hasher();
            UserManagerViewModel target = new UserManagerViewModel(user, repo, hasherAlgorithm);

            target.Username = "Mmige*";
            target.Password = "teste";
            target.Realname = "Mig";
            string error = (target as IDataErrorInfo)["Username"];
            Assert.IsFalse(String.IsNullOrEmpty(error), "Should have received error message");

            target.AddUser();            
            Assert.AreEqual(0, target.Users.Count, "Should have not addded the user");
        }

        [Test]
        public void verifyThatAfterAddingUserUIisCleared()
        {
            User user = new User();
            UserRepository repo = new UserRepository();
            PasswordHasher hasherAlgorithm = new HmacSha512Hasher();
            UserManagerViewModel target = new UserManagerViewModel(user, repo, hasherAlgorithm);

            target.Username = "mige";
            target.Password = "teste";
            target.Realname = "Mig";
            target.AddUser();

            Assert.IsTrue(String.IsNullOrEmpty(target.Username));
            Assert.IsTrue(String.IsNullOrEmpty(target.Password));
            Assert.IsTrue(String.IsNullOrEmpty(target.Realname));
        }

        [Test]
        public void verifyThatUserIsValid()
        {
            User user = new User();
            UserRepository repo = new UserRepository();
            PasswordHasher hasherAlgorithm = new HmacSha512Hasher();
            UserManagerViewModel target = new UserManagerViewModel(user, repo, hasherAlgorithm);

            target.Username = "mige";
            target.Password = "teste";
            target.Realname = "Mig";
            target.AddUser();
            Assert.AreEqual(1, target.Users.Count, "Should have addded the user");

            //User is clear
            Assert.IsTrue(String.IsNullOrEmpty(target.Username));
            Assert.IsTrue(String.IsNullOrEmpty(target.Password));
            Assert.IsTrue(String.IsNullOrEmpty(target.Realname));

            //Test User
            target.Username = "mige";
            target.Password = "teste";
            Assert.IsTrue(target.IsUserValid(), "User should be valid");
            Assert.IsTrue(String.IsNullOrEmpty((target as IDataErrorInfo).Error), "There should not be an error message");
        }

        [Test]
        public void verifyUsernameIsInvalid()
        {
            User user = new User();
            UserRepository repo = new UserRepository();
            PasswordHasher hasherAlgorithm = new HmacSha512Hasher();
            UserManagerViewModel target = new UserManagerViewModel(user, repo, hasherAlgorithm);

            target.Username = "mige";
            target.Password = "teste";
            target.Realname = "Mig";
            target.AddUser();
            Assert.AreEqual(1, target.Users.Count, "Should have addded the user");

            //User is clear
            Assert.IsTrue(String.IsNullOrEmpty(target.Username));
            Assert.IsTrue(String.IsNullOrEmpty(target.Password));
            Assert.IsTrue(String.IsNullOrEmpty(target.Realname));

            //Test User
            target.Username = "migel";
            target.Password = "teste";
            Assert.IsFalse(target.IsUserValid(), "User should be invalid");
            Assert.IsFalse(String.IsNullOrEmpty((target as IDataErrorInfo).Error), "There should be an error message");
        }

        [Test]
        public void verifyPasswordIsWrong()
        {
            User user = new User();
            UserRepository repo = new UserRepository();
            PasswordHasher hasherAlgorithm = new HmacSha512Hasher();
            UserManagerViewModel target = new UserManagerViewModel(user, repo, hasherAlgorithm);

            target.Username = "mige";
            target.Password = "teste";
            target.Realname = "Mig";
            target.AddUser();
            Assert.AreEqual(1, target.Users.Count, "Should have addded the user");

            //User is clear
            Assert.IsTrue(String.IsNullOrEmpty(target.Username));
            Assert.IsTrue(String.IsNullOrEmpty(target.Password));
            Assert.IsTrue(String.IsNullOrEmpty(target.Realname));

            //Test User
            target.Username = "mige";
            target.Password = "bacalhau";
            Assert.IsFalse(target.IsUserValid(), "User should be invalid");
            Assert.AreEqual("Passwords do not match", (target as IDataErrorInfo).Error, "Error messages should match");
        }

        [Test]
        public void verifyThatAfterCorrectingPropertiesAndUserValidNoErrorMessagesExist()
        {
            User user = new User();
            UserRepository repo = new UserRepository();
            PasswordHasher hasherAlgorithm = new HmacSha512Hasher();
            UserManagerViewModel target = new UserManagerViewModel(user, repo, hasherAlgorithm);

            target.Username = "mige";
            target.Password = "teste";
            target.Realname = "Mig";
            target.AddUser();
            Assert.AreEqual(1, target.Users.Count, "Should have addded the user");

            //Test User - Fail
            target.Username = "migel";
            target.Password = "teste";
            Assert.IsFalse(target.IsUserValid(), "User should be invalid");
            Assert.IsFalse(String.IsNullOrEmpty((target as IDataErrorInfo).Error), "There should be an error message");

            //Test User - Pass
            target.Username = "mige";
            target.Password = "teste";
            Assert.IsTrue(target.IsUserValid(), "User should be valid");
            Assert.IsTrue(String.IsNullOrEmpty((target as IDataErrorInfo).Error), "There should not be an error message");
        }
    }
}
