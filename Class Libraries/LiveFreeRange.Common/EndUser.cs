using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class EndUser
    {
        public EndUser()
        {
            _address = new Address();
            _contactInformation = new ContactInformation();
        }

        private int _endUserId;
        private int _endUserTypeId;
        private string _firstName;
        private string _lastName;
        private Address _address;
        private int _addressId;
        private ContactInformation _contactInformation;
        private int _contactInformationId;
        private string _password;
        private bool _isSubscribed;

        public int EndUserId
        {
            get { return _endUserId; }
            set { _endUserId = value; }
        }
        
        public int EndUserTypeId
        {
            get { return _endUserTypeId; }
            set { _endUserTypeId = value; }
        }

        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; }
        }

        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; }
        }

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public int AddressId
        {
            get { return _addressId; }
            set { _addressId = value; }
        }

        public ContactInformation ContactInformation
        {
            get { return _contactInformation; }
            set { _contactInformation = value; }
        }

        public int ContactInformationId
        {
            get { return _contactInformationId; }
            set { _contactInformationId = value; }
        }
        
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public bool IsSubscribed
        {
            get { return _isSubscribed; }
            set { _isSubscribed = value; }
        }
    }
}
