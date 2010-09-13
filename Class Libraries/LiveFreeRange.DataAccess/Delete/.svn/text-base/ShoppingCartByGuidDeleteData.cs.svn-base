using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Delete
{
    public class ShoppingCartByGuidDeleteData : DataAccessBase
    {
        private ShoppingCart _shoppingCart;

        public ShoppingCart ShoppingCart
        {
            get { return _shoppingCart; }
            set { _shoppingCart = value; }
        }
        private ShoppingCartByGuidDeleteDataParameters _shoppingCartByGuidDeleteDataParameters;

        public ShoppingCartByGuidDeleteDataParameters ShoppingCartDeleteDataParameters
        {
            get { return _shoppingCartByGuidDeleteDataParameters; }
            set { _shoppingCartByGuidDeleteDataParameters = value; }
        }

        public ShoppingCartByGuidDeleteData()
        {
            StoredProcedureName = StoredProcedure.Name.ShoppingCartByGuid_Delete.ToString();
        }

        public void Delete()
        {
            _shoppingCartByGuidDeleteDataParameters = new ShoppingCartByGuidDeleteDataParameters(ShoppingCart);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _shoppingCartByGuidDeleteDataParameters.Parameters;
            dbHelper.Run();
        }
    }

    public class ShoppingCartByGuidDeleteDataParameters
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

        public ShoppingCartByGuidDeleteDataParameters(ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = { new SqlParameter("@CartGuid", ShoppingCart.CartGuid) };
            Parameters = parameters;
        }
    }
}
