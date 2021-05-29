using System.Diagnostics.CodeAnalysis;

namespace WebAPI.Database.Models
{
    public class Sensor : BaseModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public int FarmId { get; set; }
        [NotNull]
        public Farm Farm { get; set; }
        public int SensorTypeId { get; set; }
        [NotNull]
        public SensorType SensorType { get; set; }
        public SensorSetting SensorSetting { get; set; }
    }
}