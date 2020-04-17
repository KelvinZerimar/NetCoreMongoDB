using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Controle.Sales.Application.Models
{
    public class SalesDto
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string Region { get; set; }

        public string Country { get; set; }

        public string Item_Type { get; set; }

        public string Sales_Channel { get; set; }

        public string Order_Priority { get; set; }

        public string Order_Date { get; set; }

        public string Ship_Date { get; set; }

        public Double Units_Sold { get; set; }

        public Double Unit_Price { get; set; }

        public Double Unit_Cost { get; set; }

        public Double Total_Revenue { get; set; }

        public Double Total_Cost { get; set; }

        public Double Total_Profit { get; set; }
    }
}
