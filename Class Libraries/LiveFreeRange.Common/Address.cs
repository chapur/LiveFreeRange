using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class Address
    {
        private int _addressId;

        public int AddressId
        {
            get { return _addressId; }
            set { _addressId = value; }
        }
        private string _addressLine;

        public string AddressLine
        {
            get { return _addressLine; }
            set { _addressLine = value; }
        }
        private string _addressLine2;

        public string AddressLine2
        {
            get { return _addressLine2; }
            set { _addressLine2 = value; }
        }
        private string _city;

        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _postalCode;

        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }
    }
}
