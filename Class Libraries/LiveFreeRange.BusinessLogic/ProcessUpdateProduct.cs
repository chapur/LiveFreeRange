using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Update;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessUpdateProduct : IBusinessLogic
    {
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public Dictionary<string, int> StockLevels { get; set; }

        public ProcessUpdateProduct()
        { 
        
        }

        public void Invoke()
        {
            ProductUpdateData productData = new ProductUpdateData();
            productData.Product = this.Product;
            productData.StockLevels = this.StockLevels;
            productData.Update();
        }
    }
}
