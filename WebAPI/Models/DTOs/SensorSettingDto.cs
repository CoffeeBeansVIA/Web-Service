namespace WebAPI.Models.DTOs
{
    public class SensorSettingDto
    {
        public double DesiredValue { get; set; }
        public double DeviationValue { get; set; }
        public int SensorId { get; set; }
        
        public SensorDto Sensor { get; set; }
    }
}