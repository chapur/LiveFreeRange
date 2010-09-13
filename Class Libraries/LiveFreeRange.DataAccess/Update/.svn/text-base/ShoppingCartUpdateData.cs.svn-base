using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Update
{
    public class ShoppingCartUpdateData :DataAccessBase
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }

        private ShoppingCartUpdateDataParameters _shoppingCartUpdateDataParameters;

        public ShoppingCartUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.ShoppingCart_Update.ToString();
        }

        public void Update()
        {
            _shoppingCartUpdateDataParameters = new ShoppingCartUpdateDataParameters(ShoppingCart);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _shoppingCartUpdateDataParameters.Parameters;
            dbHelper.Run();
        }
    }

    public class ShoppingCartUpdateDataParameters
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

        public ShoppingCartUpdateDataParameters(ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = {new SqlParameter("@Quantity", ShoppingCart.Quantity),
                                        new SqlParameter("@ShoppingCartId", ShoppingCart.ShoppingCartId)};
            Parameters = parameters;
        }
    }
}
