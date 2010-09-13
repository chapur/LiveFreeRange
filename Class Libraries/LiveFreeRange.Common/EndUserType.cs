using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class EndUserType
    {
        private int _endUserTypeId;
        private string _endUserName;

        public string EndUserName
        {
            get { return _endUserName; }
            set { _endUserName = value; }
        }

        public int EndUserTypeId
        {
            get { return _endUserTypeId; }
            set { _endUserTypeId = value; }
        }

        public EndUserType()
        { 
        }
    }
}
