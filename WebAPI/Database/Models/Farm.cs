using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Models
{
    public class Farm
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Location { get; set; }
        public int PlantKeeperId { get; set; }
        public PlantKeeper PlantKeeper { get; set; }
    }
}