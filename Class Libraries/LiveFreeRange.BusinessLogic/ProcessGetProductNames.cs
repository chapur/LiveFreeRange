using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetProductNames : IBusinessLogic
    {
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }

        public ProcessGetProductNames()
        { 
            
        }

        public void Invoke()
        {
            ProductNamesSelectData productData = new ProductNamesSelectData();
            ResultSet = productData.Get();
        }
    }
}
