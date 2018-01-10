using System;
using System.Collections.Generic;

namespace ASPNET_Januari_Reygel_Robbe.Models
{
    public class CarListViewModel
    {
        public List<CarDetailViewModel> Cars { get; set; }
        public DateTime GeneratedAt => DateTime.Now;
    }
}