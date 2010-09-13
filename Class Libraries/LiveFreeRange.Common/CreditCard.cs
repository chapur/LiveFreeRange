using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class CreditCard
    {
        private Address _address;
        private string _cardType;
        private int _expMonth;
        private int _expYear;
        private string _number;
        private string _securityCode;

        public Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string CardType
        {
            get { return _cardType; }
            set { _cardType = value; }
        }

        public int ExpMonth
        {
            get { return _expMonth; }
            set { _expMonth = value; }
        }

        public int ExpYear
        {
            get { return _expYear; }
            set { _expYear = value; }
        }

        public string Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public string SecurityCode
        {
            get { return _securityCode; }
            set { _securityCode = value; }
        }

        public CreditCard()
        {
            _address = new Address();
        }
    }
}
