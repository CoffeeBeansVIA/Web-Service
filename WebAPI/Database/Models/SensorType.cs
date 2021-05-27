using System.ComponentModel;
using System.Runtime.Serialization;

namespace WebAPI.Database.Models
{
    public class SensorType
    {
        public int Id { get; set; }
        public SensorTypes Type { get; set; }
        public string MeasurementUnit { get; set; }
    }

    public enum SensorTypes
    {
        [Description("C")]
        Temperature = 1,
        [Description("%")]
        Humidity,
        [Description("dB")]
        Sound,
        [Description("lm")]
        Light,
        [Description("ppm")]
        Co2,
        Pir
    }
}