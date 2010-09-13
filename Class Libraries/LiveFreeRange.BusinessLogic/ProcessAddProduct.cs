using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Insert;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessAddProduct : IBusinessLogic
    {
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        private Dictionary<string, int> _stockLevels;

        public Dictionary<string, int> StockLevels
        {
            get { return _stockLevels; }
            set { _stockLevels = value; }
        }

        public ProcessAddProduct()
        { 
        
        }

        public void Invoke()
        {
            ProductInsertData productData = new ProductInsertData();
            productData.StockLevels = this.StockLevels;
            productData.Product = this.Product;
            productData.Add();
        }
    }
}
