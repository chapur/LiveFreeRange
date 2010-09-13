using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class ProductColour
    {
        public ProductColour()
        { 
        
        }

        private int _productColourId;

        public int ProductColourId
        {
            get { return _productColourId; }
            set { _productColourId = value; }
        }

        private string _productColourName;

        public string ProductColourName
        {
            get { return _productColourName; }
            set { _productColourName = value; }
        }
    }
}
