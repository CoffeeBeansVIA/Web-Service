using System.ComponentModel.DataAnnotations;

namespace Tests.Models
{
    public class Sensor
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
    }
}