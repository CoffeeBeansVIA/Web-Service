using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Database.Models
{
    public class Sensor
    {
        [Key]
        public int Id { get; set; }
        
        public string Model { get; set; }
        public string Unit { get; set; }
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        public int SensorTypeId { get; set; }
        public SensorType SensorType { get; set; }
    }
}