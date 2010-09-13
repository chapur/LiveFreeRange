using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Delete
{
    public class ShoppingCartDeleteData : DataAccessBase
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }
        private ShoppingCartDeleteDataParameters _shoppingCartDeleteDataParameters;

        public ShoppingCartDeleteDataParameters ShoppingCartDeleteDataParameters
        {
            get { return _shoppingCartDeleteDataParameters; }
            set { _shoppingCartDeleteDataParameters = value; }
        }

        public ShoppingCartDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.ShoppingCart_Delete.ToString();
        }

        public void Delete()
        {
            _shoppingCartDeleteDataParameters = new ShoppingCartDeleteDataParameters(ShoppingCart);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _shoppingCartDeleteDataParameters.Parameters;
            dbHelper.Run();
        }
    }

    public class ShoppingCartDeleteDataParameters
    {
        public ShoppingCart ShoppingCart { get; set; }

        public SqlParameter[] Parameters { get; set; }

        public ShoppingCartDeleteDataParameters(ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@ShoppingCartId", ShoppingCart.ShoppingCartId)};
            Parameters = parameters;
        }
    }
}
