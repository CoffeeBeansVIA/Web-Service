namespace WebAPI.Models.Models
{
    public class SensorSetting
    {
        public int Id { get; set; }
        public double DesiredValue { get; set; }
        public double DeviationValue { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}