using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Update
{
    public class ProductUpdateData : DataAccessBase
    {
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public Dictionary<string, int> StockLevels { get; set; }

        private ProductUpdateDataParameters _productUpdateDataParameters;

        public ProductUpdateDataParameters ProductUpdateDataParameters
        {
            get { return _productUpdateDataParameters; }
            set { _productUpdateDataParameters = value; }
        }

        public ProductUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.Product_Update.ToString();
        }

        public void Update()
        {
            _productUpdateDataParameters = new ProductUpdateDataParameters(Product, StockLevels);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _productUpdateDataParameters.Parameters;
            dbHelper.Run();
        }
    }

    public class ProductUpdateDataParameters
    {
        public Dictionary<string, int> StockLevels { get; set; }

        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ProductUpdateDataParameters(Product product, Dictionary<string, int> stockLevels)
        {
            Product = product;
            StockLevels = stockLevels;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductCategoryId", Product.ProductCategoryId),
                                        new SqlParameter("@SubCategoryId", Product.SubCategoryId),
                                        new SqlParameter("@ProductName", Product.Name),
                                        new SqlParameter("@ProductImageId", Product.ImageId),
                                        //need to add ProductImageUrl
                                        new SqlParameter("@ProductImageUrl", Product.ImageUrl),
                                        new SqlParameter("@Description", Product.Description),
                                        new SqlParameter("@Price", Product.Price),
                                        new SqlParameter("@ProductId", Product.ProductId),
                                        new SqlParameter("@ProductColourId", Product.ProductColourId),
                                        new SqlParameter("@ProductSizeId", Product.ProductSizeId),
                                        new SqlParameter("@ProductWeightId", Product.ProductWeightId),
                                        //new SqlParameter("@StockLevel", Product.StockLevel)};
                                        new SqlParameter("@SmallStock", StockLevels["small"]),
                                        new SqlParameter("@MediumStock", StockLevels["medium"]),
                                        new SqlParameter("@LargeStock", StockLevels["large"])};

            Parameters = parameters;
        }
    }
}
