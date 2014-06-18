using System;
using System.ComponentModel;
using NUnit.Framework;
using ValidateMe;

namespace BusinessObjectsTest
{
    [TestFixture]
    public class ContactTest
    {
        [Test]
        public void testCreateContact()
        {
            Contact contact1 = new Contact();
            contact1.Name = "MyNAme";
            contact1.Telephone = "0909-11290";
            contact1.Email = "myemail@email";            
        }
        [Test]
        public void testSettingInvalidName()
        {
            Contact target = new Contact();
            target.Name = "1232";
            string error = (target as IDataErrorInfo)["Name"];
            Assert.IsFalse(String.IsNullOrEmpty(error), "Error message should be returned");
        }
        [Test]
        public void testSettingInvalidePhone()
        {
            Contact target = new Contact();
            target.Telephone = "abc-afgd";
            string error = (target as IDataErrorInfo)["Telephone"];
            Assert.IsFalse(String.IsNullOrEmpty(error), "Error message should be returned");
        }
        [Test]
        public void testSettingValidEmail()
        {
            Contact target = new Contact();
            target.Email = "miguel.ferna@gmail.com";
            string error = (target as IDataErrorInfo)["Email"];
            Assert.IsTrue(String.IsNullOrEmpty(error), "No error message should be returned");

            target.Email = "a_c_f@gmail.com";
            error = (target as IDataErrorInfo)["Email"];
            Assert.IsTrue(String.IsNullOrEmpty(error), "No error message should be returned");

            target.Email = "a123@gmail.com";
            error = (target as IDataErrorInfo)["Email"];
            Assert.IsTrue(String.IsNullOrEmpty(error), "No error message should be returned");

            target.Email = "a123@gmail21.com";
            error = (target as IDataErrorInfo)["Email"];
            Assert.IsTrue(String.IsNullOrEmpty(error), "No error message should be returned");
        }
        [Test]
        public void testSettingInvalidEmail()
        {
            Contact target = new Contact();
            target.Email = "a123@gmail21.com21";
            string error = (target as IDataErrorInfo)["Email"];
            Assert.IsFalse(String.IsNullOrEmpty(error), "Error message should be returned");

            target.Email = "a1 23@gmail21.com";
            error = (target as IDataErrorInfo)["Email"];
            Assert.IsFalse(String.IsNullOrEmpty(error), "Error message should be returned");

            target.Email = " a123@gmail21.com";
            error = (target as IDataErrorInfo)["Email"];
            Assert.IsFalse(String.IsNullOrEmpty(error), "Error message should be returned");
        }
    }
}
