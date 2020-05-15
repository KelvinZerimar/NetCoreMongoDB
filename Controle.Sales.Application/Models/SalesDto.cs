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

        public string Region { get; set; } // Region 

        public string Country { get; set; } // Pais

        public string Item_Type { get; set; } // Tipo de item

        public string Sales_Channel { get; set; } // Canal de Venta

        public string Order_Priority { get; set; } // Prioridad de orden

        public string Order_Date { get; set; } // Fecha de Orden

        public string Ship_Date { get; set; } // Fecha de envío 

        public Double Units_Sold { get; set; } // Unidades Vendidas

        public Double Unit_Price { get; set; } // Precio Unitario

        public Double Unit_Cost { get; set; } // Costo Unitario

        public Double Total_Revenue { get; set; } // Ingresos totales

        public Double Total_Cost { get; set; } // Coste Total

        public Double Total_Profit { get; set; } // Benefocio Total
    }
}
