using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class ProductCategory
    {
        public ProductCategory()
        { }

        private int _productCategoryId;

        public int ProductCategoryId
        {
            get { return _productCategoryId; }
            set { _productCategoryId = value; }
        }
        private string _productCategoryName;

        public string ProductCategoryName
        {
            get { return _productCategoryName; }
            set { _productCategoryName = value; }
        }
    }
}
