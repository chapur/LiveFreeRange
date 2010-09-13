using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Insert
{
    public class ProductInsertData : DataAccessBase
    {
        private Dictionary<string, int> _stockLevels;

        public Dictionary<string, int> StockLevels
        {
            get { return _stockLevels; }
            set { _stockLevels = value; }
        }

        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }
        private ProductInsertDataParameters _productInsertDataParameters;

        public ProductInsertDataParameters ProductInsertDataParameters
        {
            get { return _productInsertDataParameters; }
            set { _productInsertDataParameters = value; }
        }

        public ProductInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.Product_Insert.ToString();
        }

        public void Add()
        {
            _productInsertDataParameters = new ProductInsertDataParameters(Product, StockLevels);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _productInsertDataParameters.Parameters;
            dbHelper.Run();
        }
    }

    public class ProductInsertDataParameters
    {
        private Dictionary<string, int> _stockLevels;
        private Product _product;
        private SqlParameter[] _parameters;

        public Dictionary<string, int> StockLevels
        {
            get { return _stockLevels; }
            set { _stockLevels = value; }
        }

        public Product Product
        {
          get { return _product; }
          set { _product = value; }
        }

        public SqlParameter[] Parameters
        {
          get { return _parameters; }
          set { _parameters = value; }
        }

        public ProductInsertDataParameters(Product product, Dictionary<string, int> stockLevels)
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
                                        new SqlParameter("@ProductImageUrl", Product.ImageUrl),
                                        new SqlParameter("@Description", Product.Description),
                                        new SqlParameter("@Price", Product.Price),
                                        new SqlParameter("@ColourId", Product.ProductColourId),
                                        //new SqlParameter("@SizeId", Product.ProductSizeId),
                                        new SqlParameter("@WeightId", Product.ProductWeightId),
                                        //new SqlParameter("@StockLevel", Product.StockLevel),
                                        new SqlParameter("@SmallStock", StockLevels["small"]),
                                        new SqlParameter("@MediumStock", StockLevels["medium"]),
                                        new SqlParameter("@LargeStock", StockLevels["large"])};

            Parameters = parameters;
        }

    }
}
