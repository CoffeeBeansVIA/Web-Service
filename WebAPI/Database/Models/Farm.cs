using System.Collections.Generic;

namespace WebAPI.Models.Models
{
    public class Farm
    {
        public int Id { get; set; }
        public string EUI { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<PlantKeeper> PlantKeepers { get; set; }
        public ICollection<Sensor> Sensors { get; set; }
    }
}