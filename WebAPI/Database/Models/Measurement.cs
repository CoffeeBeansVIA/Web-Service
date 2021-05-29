using System;

namespace WebAPI.Database.Models
{
    public class Measurement
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
        
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}