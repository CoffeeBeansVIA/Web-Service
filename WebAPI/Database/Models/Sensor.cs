using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Models
{
    public class Sensor
    {
        [Key]
        public int Id { get; set; }
        
        public string Model { get; set; }
        public string Unit { get; set; }
        public Farm Farm { get; set; }
        public SensorType SensorType { get; set; }


    }
}