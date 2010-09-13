using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Update;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessNewsletterUnsubscribe : IBusinessLogic
    {
        private EndUser _endUser;

        public EndUser EndUser
        {
            get { return _endUser; }
            set { _endUser = value; }
        }

        public ProcessNewsletterUnsubscribe()
        { 
        
        }

        public void Invoke()
        {
            NewsletterUpdateData newsletterUpdateData = new NewsletterUpdateData();
            newsletterUpdateData.EndUser = this.EndUser;
            newsletterUpdateData.Update();
        }
    }
}
