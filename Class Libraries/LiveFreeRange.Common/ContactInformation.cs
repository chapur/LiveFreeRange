using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LiveFreeRange.Common
{
    public class ContactInformation
    {
        private int _contactInformationId;

        public int ContactInformationId
        {
            get { return _contactInformationId; }
            set { _contactInformationId = value; }
        }
        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _phone2;

        public string Phone2
        {
            get { return _phone2; }
            set { _phone2 = value; }
        }
        private string _fax;

        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
    }
}
