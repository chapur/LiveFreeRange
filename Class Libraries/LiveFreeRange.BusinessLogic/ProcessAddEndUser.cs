using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Insert;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessAddEndUser : IBusinessLogic
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }

        public ProcessAddEndUser()
        { 
        
        }

        public void Invoke()
        {
            EndUserInsertData endUserData = new EndUserInsertData();
            endUserData.EndUser = this.EndUser;
            endUserData.Add();
            this.EndUser.EndUserId = endUserData.EndUser.EndUserId;
        }

    }
}
