using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Insert
{
    public class ShoppingCartInsertData : DataAccessBase
    {
        private ShoppingCart _shoppingCart;
        private ShoppingCartInsertDataParameters _shoppingCartInsertDataParameters;

        public ShoppingCartInsertDataParameters ShoppingCartInsertDataParameters
        {
            get { return _shoppingCartInsertDataParameters; }
            set { _shoppingCartInsertDataParameters = value; }
        }

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        public ShoppingCartInsertData()
        {
            StoredProcedureName = StoredProcedure.Name.ShoppingCart_Insert.ToString();
        }

        public void Add()
        {
            _shoppingCartInsertDataParameters = new ShoppingCartInsertDataParameters(ShoppingCart);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _shoppingCartInsertDataParameters.Parameters;
            dbHelper.Run();

        }
    }

    public class ShoppingCartInsertDataParameters
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }
        private SqlParameter[] _parameters;

        public SqlParameter[] Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        public ShoppingCartInsertDataParameters(ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = {new SqlParameter("@CartGUID", ShoppingCart.CartGuid),
                                        new SqlParameter("@ProductId", ShoppingCart.ProductId),
                                        new SqlParameter("@Quantity", ShoppingCart.Quantity),
                                        new SqlParameter("@ProductSizeId", ShoppingCart.ProductSizeId)};
                                        //new SqlParameter("@ProductSize", ShoppingCart.ProductSize)};

            Parameters = parameters;
        }
    }
}
