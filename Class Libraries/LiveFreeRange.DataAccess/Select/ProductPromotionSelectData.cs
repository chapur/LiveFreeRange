using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductPromotionSelectData : DataAccessBase
    {
        private Product _product;

        public Product Product
        {
            get { return _product; }
            set { _product = value; }
        }

        public ProductPromotionSelectData()
        {
            base.StoredProcedureName = StoredProcedure.Name.ProductPromotion_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;

            ProductPromotionSelectDataParameters _productPromotion = new ProductPromotionSelectDataParameters(Product);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _productPromotion.Parameters);

            return ds;

        }
    }

    public class ProductPromotionSelectDataParameters
    {
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

        public ProductPromotionSelectDataParameters(Product product)
        {
            Product = product;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductId", Product.ProductId)};

            Parameters = parameters;
        }
    }
}
