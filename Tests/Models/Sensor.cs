using System.ComponentModel.DataAnnotations;

namespace Tests.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Unit { get; set; }
        
        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        
        public int SensorTypeId { get; set; }
        public SensorType SensorType { get; set; }
        
        public SensorSetting SensorSetting { get; set; }
    }
}