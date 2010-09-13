using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace LiveFreeRange.Operational
{
    public class CalculationManager
    {
        public static decimal CalcSalesTax(decimal amount)
        {
            decimal total;

            decimal taxrate = (Convert.ToDecimal(ConfigurationManager.AppSettings["TaxRate"]) / 100);
            total = (amount * taxrate);

            return total;
        }
    }
}
