using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetPromotions : IBusinessLogic
    {
        private DataSet _resultSet;

        public DataSet ResultSet
        {
            get { return _resultSet; }
            set { _resultSet = value; }
        }
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public ProcessGetPromotions()
        { 
        
        }

        public void Invoke()
        {
            ProductPromotionSelectData promotionData = new ProductPromotionSelectData();
            promotionData.Product = this.Product;
            this.ResultSet = promotionData.Get();
        }
    }
}
