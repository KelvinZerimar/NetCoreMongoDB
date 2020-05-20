using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Application.App.Models
{
    public class SalesDto
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        public int OrderID { get; set; }
        public string Region { get; set; } 
        public string Country { get; set; } 
        public string ItemType { get; set; }
        public string SalesChannel { get; set; } 
        public string OrderPriority { get; set; } 
        public string OrderDate { get; set; } 
        public string ShipDate { get; set; } 
        public decimal UnitsSold { get; set; } 
        public decimal UnitPrice { get; set; } 
        public decimal UnitCost { get; set; } 
        public decimal TotalRevenue { get; set; } 
        public decimal TotalCost { get; set; } 
        public decimal TotalProfit { get; set; } 
    }
}
