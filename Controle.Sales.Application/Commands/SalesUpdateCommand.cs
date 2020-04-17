using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Sales.Application.Commands
{
    public class SalesUpdateCommand
    {
        public string Id { get; set; }
        public Int32 Order_ID { get; set; }

        public String Region { get; set; }

        public String Country { get; set; }

        public String Item_Type { get; set; }

        public String Sales_Channel { get; set; }

        public String Order_Priority { get; set; }

        public String Order_Date { get; set; }

        public String Ship_Date { get; set; }

        public Double Units_Sold { get; set; }

        public Double Unit_Price { get; set; }

        public Double Unit_Cost { get; set; }

        public Double Total_Revenue { get; set; }

        public Double Total_Cost { get; set; }

        public Double Total_Profit { get; set; }
    }
}
