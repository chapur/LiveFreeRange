using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LiveFreeRange.Common
{
    public class Product
    {
        public Product()
        {
            _productCategory = new ProductCategory();
            _subCategory = new SubCategory();
            _productColour = new ProductColour();
            _productWeight = new ProductWeight();
            _productStockLevel = new ProductStockLevel();
        }
        private ProductStockLevel _productStockLevel;
        public ProductStockLevel ProductStockLevel { get; set; }

        private int _productId;

        public int ProductId
        {
            get { return _productId; }
            set { _productId = value; }
        }
        private int _productCategoryId;

        public int ProductCategoryId
        {
            get { return _productCategoryId; }
            set { _productCategoryId = value; }
        }

        private int _subCategoryId;

        public int SubCategoryId
        {
            get { return _subCategoryId; }
            set { _subCategoryId = value; }
        }

        private string _subCategoryName;

        public string SubCategoryName
        {
            get { return _subCategoryName; }
            set { _subCategoryName = value; }
        }

        private string _subCategoryDisplayName;

        public string SubCategoryDisplayName
        {
            get { return _subCategoryDisplayName; }
            set { _subCategoryDisplayName = value; }
        }

        private ProductColour _productColour;

        public ProductColour ProductColour
        {
            get { return _productColour; }
            set { _productColour = value; }
        }

        private ProductWeight _productWeight;

        public ProductWeight ProductWeight
        {
            get { return _productWeight; }
            set { _productWeight = value; }
        }

        private ProductSize _productSize;

        public ProductSize ProductSize
        {
            get { return _productSize; }
            set { _productSize = value; }
        }

        private ProductCategory _productCategory;

        public ProductCategory ProductCategory
        {
            get { return _productCategory; }
            set { _productCategory = value; }
        }

        private SubCategory _subCategory;

        public SubCategory SubCategory
        {
            get { return _subCategory; }
            set { _subCategory = value; }
        }

        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private int _imageId;

        public int ImageId
        {
            get { return _imageId; }
            set { _imageId = value; }
        }

        private string _imageUrl;

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        private decimal _price;

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        private int _productColourId;

        public int ProductColourId
        {
            get { return _productColourId; }
            set { _productColourId = value; }
        }

        private int _productSizeId;

        public int ProductSizeId
        {
            get { return _productSizeId; }
            set { _productSizeId = value; }
        }

        private int _productWeightId;

        public int ProductWeightId
        {
            get { return _productWeightId; }
            set { _productWeightId = value; }
        }

        private int _stockLevel;

        public int StockLevel
        {
            get { return _stockLevel; }
            set { _stockLevel = value; }
        }


    }
}
