using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Models
{
    public class SensorType
    {
        [Key]
        public int Id { get; set; }
        
        public string Type { get; set; }

    }
}