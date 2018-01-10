using System;
using ASPNET_Januari_Reygel_Robbe.Entities;

namespace ASPNET_Januari_Reygel_Robbe.Models
{
    public class CarDetailViewModel
    {
        public string Color;
        public string Plate { get; set; }
        public string Owner { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
    }
}