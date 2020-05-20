using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Controle.Sales.Application.Models
{
    public class SalesDto
    {
        [BsonId]
        public ObjectId ObjectId { get; set; }
        public int OrderID { get; set; }
        public string Region { get; set; } // Region 
        public string Country { get; set; } // Pais
        public string ItemType { get; set; } // Tipo de item
        public string SalesChannel { get; set; } // Canal de Venta
        public string OrderPriority { get; set; } // Prioridad de orden
        public string OrderDate { get; set; } // Fecha de Orden
        public string ShipDate { get; set; } // Fecha de envío 
        public decimal UnitsSold { get; set; } // Unidades Vendidas
        public decimal UnitPrice { get; set; } // Precio Unitario
        public decimal UnitCost { get; set; } // Costo Unitario
        public decimal TotalRevenue { get; set; } // Ingresos totales
        public decimal TotalCost { get; set; } // Coste Total
        public decimal TotalProfit { get; set; } // Benefocio Total
    }
}
