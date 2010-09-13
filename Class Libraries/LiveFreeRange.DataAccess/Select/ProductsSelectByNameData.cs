using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class ProductsSelectByNameData : DataAccessBase
    {
        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private int _productColourId;

        public int ProductColourId
        {
            get { return _productColourId; }
            set { _productColourId = value; }
        }

        public ProductsSelectByNameData()
        {
            StoredProcedureName = StoredProcedure.Name.ProductsByName_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            ProductsSelectByNameDataParameters _productSelectByNameParameters = new ProductsSelectByNameDataParameters(ProductName, ProductColourId);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _productSelectByNameParameters.Parameters);
            return ds;
        }
    }

    public class ProductsSelectByNameDataParameters
    {
        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        private int _productColourId;

        public int ProductColourId
        {
            get { return _productColourId; }
            set { _productColourId = value; }
        }

        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ProductsSelectByNameDataParameters(string productName, int productColourId)
        {
            this.ProductName = productName;
            this.ProductColourId = productColourId;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@ProductName", ProductName),
                                        new SqlParameter("@ProductColourId", ProductColourId)};
            this.Parameters = parameters;
        }
    }
}
