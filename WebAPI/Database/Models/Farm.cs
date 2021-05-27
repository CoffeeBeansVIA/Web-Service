using System.Collections.Generic;

namespace WebAPI.Database.Models
{
    public class Farm : BaseModel
    {
        public int Id { get; set; }
        public string Eui { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<PlantKeeper> PlantKeepers { get; set; }
        
        public ICollection<Sensor> Sensors { get; set; }
    }
}