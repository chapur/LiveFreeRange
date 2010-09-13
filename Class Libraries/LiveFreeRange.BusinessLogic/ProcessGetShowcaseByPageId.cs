using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetShowcaseByPageId : IBusinessLogic
    {
        private DataSet _resultSet;
        private int _pageId;
        
        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public int PageId
        {
            get { return _pageId; }
            set { _pageId = value; }
        }

        public ProcessGetShowcaseByPageId()
        { 
        
        }

        public void Invoke()
        {
            ShowcaseSelectByPageIdData selectShowcase = new ShowcaseSelectByPageIdData();
            selectShowcase.PageId = PageId;
            ResultSet = selectShowcase.Get();
        }
    }
}
