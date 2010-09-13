using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using LiveFreeRange.DataAccess.Select;

namespace LiveFreeRange.BusinessLogic
{
    public class ProcessGetProductStockLevelById : IBusinessLogic
    {
        public int ProductId { get; set; }
        public DataSet ResultSet { get; set; }

        public ProcessGetProductStockLevelById()
        { 
        
        }
        
        public void Invoke()
        {
            ProductStockLevelSelectByIdData productStockLevelData = new ProductStockLevelSelectByIdData();
            productStockLevelData.ProductId = this.ProductId;
            ResultSet = productStockLevelData.Get();
        }
    }
}
