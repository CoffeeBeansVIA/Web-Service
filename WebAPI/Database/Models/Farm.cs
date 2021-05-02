using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Models
{
    public class Farm
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<PlantKeeper> PlantKeepers { get; set; }
        public ICollection<Sensor> Sensors { get; set; }
    }
}