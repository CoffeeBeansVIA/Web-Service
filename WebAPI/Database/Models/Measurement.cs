using System.ComponentModel.DataAnnotations;

namespace WebAPI.Database.Models
{
    public class Measurement
    {
        [Key]
        public int Id { get; set; }

        public string Time { get; set; }
        public string Date { get; set; }
        public decimal Value { get; set; }
        public Sensor Sensor { get; set; }

    }
}