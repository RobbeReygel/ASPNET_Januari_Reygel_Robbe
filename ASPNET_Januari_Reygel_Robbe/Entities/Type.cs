using System.Collections.Generic;

namespace ASPNET_Januari_Reygel_Robbe.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public virtual IEnumerable<Car> Cars { get; set; }
    }
}