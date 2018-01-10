using System;
using System.Collections.Generic;

namespace ASPNET_Januari_Reygel_Robbe.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string Plate { get; set; }
        public string Color { get; set; }
        public DateTime PurchaseDate { get; set; }
        public virtual Owner Owner { get; set; }
        public virtual Type Type { get; set; }
    }
}