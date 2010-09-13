using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessNewsletter : IBusinessLogic
    {
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public ProcessNewsletter()
        {

        }

        public void Invoke()
        {
            NewsletterSelectData newsletterData = new NewsletterSelectData();
            this.ResultSet = newsletterData.Get();
        }
    }
}
