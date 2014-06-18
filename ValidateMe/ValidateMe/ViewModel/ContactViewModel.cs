using System;
using System.ComponentModel;

namespace ValidateMe
{
    public class ContactViewModel : WorkspaceViewModel, IDataErrorInfo
    {
        private Contact _contact;

        public ContactViewModel(Contact contact)
        {
            _contact = contact;
        }

        #region Properties

        public String Name
        {
            get
            {
                return _contact.Name;
            }
            set
            {
                _contact.Name = value;
            }
        }

        public String Telephone
        {
            get
            {
                return _contact.Telephone;
            }
            set
            {
                _contact.Telephone = value;
            }
        }

        public String Email
        {
            get
            {
                return _contact.Email;
            }
            set
            {
                _contact.Email = value;
            }
        }
        #endregion

        #region IDataErrorInfo Members

        string IDataErrorInfo.Error
        {
            get { return (_contact as IDataErrorInfo).Error; }
        }

        string IDataErrorInfo.this[string propertyName]
        {
            get 
            {                
                return (_contact as IDataErrorInfo)[propertyName];
            }
        }

        #endregion
    }
}
