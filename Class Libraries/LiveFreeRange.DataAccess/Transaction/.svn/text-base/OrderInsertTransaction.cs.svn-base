using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LiveFreeRange.Common;
using LiveFreeRange.DataAccess.Insert;
using LiveFreeRange.DataAccess.Delete;

namespace LiveFreeRange.DataAccess.Transaction
{
    public class OrderInsertTransaction : TransactionBase
    {
        public OrderInsertTransaction()
        { 
        
        }

        public void Begin(Orders orders)
        {
            command = connection.CreateCommand();
            transaction = connection.BeginTransaction("OrderInsert");
            command.Connection = connection;
            command.Transaction = transaction;

            OrderInsertData orderAdd = new OrderInsertData();
            OrderDetailsInsertData orderDetailsAdd = new OrderDetailsInsertData();
            ShoppingCartByGuidDeleteData shoppingCartDelete = new ShoppingCartByGuidDeleteData();

            try
            {
                //insert order
                orderAdd.Orders = orders;
                orderAdd.Add(transaction);
                
                //insert order details
                //Products.Count only applies of using collection rather than array.
                for (int i = 0; i < orders.OrderDetails.Products.Length; i++)
                {
                    orderDetailsAdd.OrderDetails.OrderId = orders.OrderId;
                    orderDetailsAdd.OrderDetails.ProductId = orders.OrderDetails.Products[i].ProductId;
                    orderDetailsAdd.OrderDetails.Quantity = orders.OrderDetails.Products[i].Quantity;

                    orderDetailsAdd.Add(transaction);
                }
                transaction.Commit();
            }
            catch(Exception ex)
            {
                transaction.Rollback("OrderInsert");
                throw ex;
            }
        }
    }
}
