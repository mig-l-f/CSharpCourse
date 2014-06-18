using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ValidateMe;
using System.ComponentModel;

namespace BusinessObjectsTest
{
    [TestFixture]
    public class ContactViewModelTest
    {
        
        [Test]
        public void testCreateNewContactViewModel()
        {
            Contact contact = new Contact();
            ContactViewModel target = new ContactViewModel(contact);

        }
        
        [Test]
        public void testValidationOfContactNameIsValid()
        {
            Contact contact = new Contact();
            ContactViewModel target = new ContactViewModel(contact);

            contact.Name = "Miguel Andre";
            string error = (target as IDataErrorInfo)["Name"];
            Assert.IsTrue(String.IsNullOrEmpty(error), "No error message should be returned");
        }

        [Test]
        public void testValidationOfContactTelephoneIsInvalid()
        {
            Contact contact = new Contact();
            ContactViewModel target = new ContactViewModel(contact);

            contact.Telephone = "adbd";
            string error = (target as IDataErrorInfo)["Telephone"];
            Assert.IsFalse(String.IsNullOrEmpty(error), "Error message should be returned");
        }


        // In CustomerViewModelTests.cs 
/*        [TestMethod] 
        public void TestCustomerType() 
        { 
            Customer cust = Customer.CreateNewCustomer(); 
            CustomerRepository repos = new CustomerRepository( Constants.CUSTOMER_DATA_FILE); 
            CustomerViewModel target = new CustomerViewModel(cust, repos); 
            target.CustomerType = "Company" 
            Assert.IsTrue(cust.IsCompany, "Should be a company"); 
            target.CustomerType = "Person"; 
            Assert.IsFalse(cust.IsCompany, "Should be a person"); 
            target.CustomerType = "(Not Specified)"; 
            string error = (target as IDataErrorInfo)["CustomerType"]; 
            Assert.IsFalse(String.IsNullOrEmpty(error), "Error message should be returned"); 
        }*/
    }
}
