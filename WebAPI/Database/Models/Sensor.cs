namespace WebAPI.Database.Models
{
    public class Sensor : BaseModel
    {
        public int Id { get; set; }
        public string Model { get; set; }

        public int FarmId { get; set; }
        public Farm Farm { get; set; }
        
        public int SensorTypeId { get; set; }
        public SensorType SensorType { get; set; }
        
        public SensorSetting SensorSetting { get; set; }
    }
}