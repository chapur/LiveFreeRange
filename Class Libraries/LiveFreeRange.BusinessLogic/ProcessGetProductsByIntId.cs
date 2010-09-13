using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetProductsByIntId : IBusinessLogic
    {
        private int _productId;

        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }
 
        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        public ProcessGetProductsByIntId()
        { 
        
        }
        
        public void Invoke()
        {
            ProductSelectByIntIdData productData = new ProductSelectByIntIdData();
            productData.ProductId = this.ProductId;
            ResultSet = productData.Get();
        }
    }
}
