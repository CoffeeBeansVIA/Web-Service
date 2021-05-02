using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Models
{
    public class SensorType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }
}