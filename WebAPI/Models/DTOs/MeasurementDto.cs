namespace WebAPI.Models.DTOs
{
    public class MeasurementDto
    {
        public int Id { get; set; }
        public string Time { get; set; }
        public string Date { get; set; }
        public decimal Value { get; set; }
        public int SensorId { get; set; }
        public SensorDto Sensor { get; set; }
    }
}