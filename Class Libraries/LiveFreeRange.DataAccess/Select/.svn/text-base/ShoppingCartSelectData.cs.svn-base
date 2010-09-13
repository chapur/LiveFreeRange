using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Select
{
    public class ShoppingCartSelectData : DataAccessBase
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        public ShoppingCartSelectData()
        {
            StoredProcedureName = StoredProcedure.Name.ShoppingCart_Select.ToString();
        }

        public DataSet Get()
        {
            DataSet ds;
            ShoppingCartSelectDataParameters _shoppingCartSelectDataParameters = new ShoppingCartSelectDataParameters(ShoppingCart);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            ds = dbHelper.Run(base.ConnectionString, _shoppingCartSelectDataParameters.Parameters);
            return ds;
        }
    }

    public class ShoppingCartSelectDataParameters
    {
        private ShoppingCart _shoppingCart;
        private SqlParameter[] _parameters;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ShoppingCartSelectDataParameters(ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@CartGUID", ShoppingCart.CartGuid) };
            Parameters = parameters;
        }
    }
}
