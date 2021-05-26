using System.Collections.Generic;

namespace WebAPI.Models.DTOs
{
    public class FarmDto
    {
        public int Id { get; set; }
        public string EUI { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }

    public class FarmDetailDto
    {
        public int Id { get; set; }
        public string EUI { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public IEnumerable<PlantKeeperDetailDto> PlantKeepers { get; set; }
        public IEnumerable<SensorDetailDto> Sensors { get; set; }
    }
}