using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class ProductStockLevel
    {
        public ProductStockLevel()
        { }

        public int ProductSizeId { get; set; }

        public string ProductSizeName { get; set; }

        public int StockLevel { get; set; }

        public string Availability { get; set; }
    }
}
