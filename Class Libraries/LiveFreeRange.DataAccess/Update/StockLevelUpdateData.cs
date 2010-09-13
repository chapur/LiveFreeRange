using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

using LiveFreeRange.Common;

namespace LiveFreeRange.DataAccess.Update
{
    public class StockLevelUpdateData : DataAccessBase
    {
        public ShoppingCart ShoppingCart { get; set; }

        private StockLevelUpdateDataParameters _stockLevelUpdateDataParameters;

        public StockLevelUpdateData()
        {
            StoredProcedureName = StoredProcedure.Name.StockLevel_Update.ToString();
        }

        public void Update()
        {
            _stockLevelUpdateDataParameters = new StockLevelUpdateDataParameters(ShoppingCart);
            DataBaseHelper dbHelper = new DataBaseHelper(StoredProcedureName);
            dbHelper.Parameters = _stockLevelUpdateDataParameters.Parameters;
            dbHelper.Run();
        }
    }

    public class StockLevelUpdateDataParameters
    {
        public ShoppingCart ShoppingCart { get; set; }
        public SqlParameter[] Parameters { get; set; }

        public StockLevelUpdateDataParameters(ShoppingCart shoppingCart)
        {
            ShoppingCart = shoppingCart;
            this.Build();
        }

        private void Build()
        {
            SqlParameter[] parameters = {new SqlParameter("@Quantity", ShoppingCart.Quantity),
                                        new SqlParameter("@ProductId", ShoppingCart.ProductId),
                                        new SqlParameter("@ProductSizeId", ShoppingCart.ProductSizeId)};

            Parameters = parameters;
        }
    }
}
