using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Sales.Application.Commands
{
    public class SalesCommand
    {
        public int OrderID { get; set; }
        public String Region { get; set; }

        public String Country { get; set; }

        public String ItemType { get; set; }

        public String SalesChannel { get; set; }

        public String OrderPriority { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShipDate { get; set; }

        public decimal UnitsSold { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal UnitCost { get; set; }

        public decimal TotalRevenue { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalProfit { get; set; }
    }
}
