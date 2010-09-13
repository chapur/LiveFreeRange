using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Update;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessUpdateStockLevel
    {
        public ShoppingCart ShoppingCart { get; set; }

        public ProcessUpdateStockLevel()
        { }

        public void Invoke()
        {
            StockLevelUpdateData stockLevelData = new StockLevelUpdateData();
            stockLevelData.ShoppingCart = this.ShoppingCart;
            stockLevelData.Update();
        }
    }
}
