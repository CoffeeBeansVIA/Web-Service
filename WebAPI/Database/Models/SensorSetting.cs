namespace WebAPI.Database.Models
{
    public class SensorSetting : BaseModel
    {
        public int Id { get; set; }
        public int DesiredValue { get; set; }
        public int DeviationValue { get; set; }
        public int SensorId { get; set; }
        public Sensor Sensor { get; set; }
    }
}