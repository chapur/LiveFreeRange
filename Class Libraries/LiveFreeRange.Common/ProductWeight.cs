using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class ProductWeight
    {
        public ProductWeight()
        { 
        
        }

        private int _productWeightId;

        public int ProductWeightId
        {
            get { return _productWeightId; }
            set { _productWeightId = value; }
        }

        private string _productWeightName;

        public string ProductWeightName
        {
            get { return _productWeightName; }
            set { _productWeightName = value; }
        }
    }
}
