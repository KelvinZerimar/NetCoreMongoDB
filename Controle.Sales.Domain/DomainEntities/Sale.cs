using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controle.Sales.Domain.DomainEntities
{
    public class Sale
    {
        public ObjectId Id { get; private set; }


        [BsonElement("Order ID")]
        public Int32 Order_ID { get; set; }


        public String Region { get; set; }


        public String Country { get; set; }

        [BsonElement("Item Type")]
        public String Item_Type { get; set; }

        [BsonElement("Sales Channel")]
        public String Sales_Channel { get; set; }

        [BsonElement("Order Priority")]
        public String Order_Priority { get; set; }

        [BsonElement("Order Date")]
        public String Order_Date { get; set; }

        [BsonElement("Ship Date")]
        public String Ship_Date { get; set; }

        [BsonElement("Units Sold")]
        public Double Units_Sold { get; set; }

        [BsonElement("Unit Price")]
        public Double Unit_Price { get; set; }

        [BsonElement("Unit Cost")]
        public Double Unit_Cost { get; set; }

        [BsonElement("Total Revenue")]
        public Double Total_Revenue { get; set; }

        [BsonElement("Total Cost")]
        public Double Total_Cost { get; set; }

        [BsonElement("Total Profit")]
        public Double Total_Profit { get; set; }
    }
}
