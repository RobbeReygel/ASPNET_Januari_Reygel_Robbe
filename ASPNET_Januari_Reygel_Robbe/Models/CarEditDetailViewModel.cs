using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ASPNET_Januari_Reygel_Robbe.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ASPNET_Januari_Reygel_Robbe.Models
{
    public class CarEditDetailViewModel
    {
        [Required]
        public string Plate { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public int? TypeId { get; set; }
        public string Owner { get; set; }
        public int? OwnerId { get; set; }
        public List<SelectListItem> Types { get; set; }
        public List<SelectListItem> Owners { get; set; }
    }
}