using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetProducts : IBusinessLogic
    {
        private DataSet _resultSet;
        
        public ProcessGetProducts()
        { 
        
        }
        
        public void Invoke()
        {
            ProductSelectData productData = new ProductSelectData();
            ResultSet = productData.Get();
        }

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }
    }
}
