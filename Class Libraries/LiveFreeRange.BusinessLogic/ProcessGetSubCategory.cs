using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetSubCategory : IBusinessLogic
    {
        public ProcessGetSubCategory()
        { 
        
        }

        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public void Invoke()
        {
            SubCategorySelectData subCategoryData = new SubCategorySelectData();
            ResultSet = subCategoryData.Get();
        }
    }
}
