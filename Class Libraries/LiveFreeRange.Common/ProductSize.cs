using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace LiveFreeRange.Common
{
    public class ProductSize
    {
        public ProductSize(DataRow dr)
        {
            _productId = Convert.ToInt32(dr["ProductId"]);
            _productSizeId = Convert.ToInt32(dr["ProductSizeId"]);
            _stockLevel = dr["StockLevel"].ToString();
            _productSizeName = dr["ProductSizeName"].ToString();
            _availability = dr["Availability"].ToString();
        }

        private string _availability;

        public string Availability
        {
            get { return _availability; }
            set { _availability = value; }
        }

        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        private string _stockLevel;

        public string StockLevel
        {
            get { return _stockLevel; }
            set { _stockLevel = value; }
        }

        private int _productSizeId;

        public int ProductSizeId
        {
            get { return _productSizeId; }
            set { _productSizeId = value; }
        }

        private string _productSizeName;

        public string ProductSizeName
        {
            get { return _productSizeName; }
            set { _productSizeName = value; }
        }
    }
}
