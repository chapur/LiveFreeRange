using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using LiveFreeRange.Common;

namespace LiveFreeRange.Common
{
    public class ProductCollection
    {
        public ProductCollection(DataRow dr)
        {
            _productId = Convert.ToInt32(dr["ProductId"]);
            _categoryId = Convert.ToInt32(dr["ProductCategoryId"]);
            _productName = dr["ProductName"].ToString();
            _productDescription = dr["ProductDescription"].ToString();
            _productColour = dr["ProductColourName"].ToString();
            _productImageUrl = dr["ProductImageUrl"].ToString();
            //_stockLevel = Convert.ToInt32(dr["StockLevel"]);
        }
        //private int _stockLevel;
        private int _categoryId;
        public int CategoryId { get; set; }

        private int _stockLevel;

        //public int StockLevel
        //{
        //    get { return _stockLevel; }
        //    set { _stockLevel = value; }
        //}

        private string _productImageUrl;

        public string ProductImageUrl
        {
            get { return _productImageUrl; }
            set { _productImageUrl = value; }
        }

        private string _productColour;

        public string ProductColour
        {
            get { return _productColour; }
            set { _productColour = value; }
        }

        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }
        private string _productDescription;

        public string ProductDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; }
        }
    }
}
