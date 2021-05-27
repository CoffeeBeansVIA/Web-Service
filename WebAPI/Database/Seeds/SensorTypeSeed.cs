using System.Collections.Generic;
using WebAPI.Database.Models;
using WebAPI.Utils;

namespace WebAPI.Database.Seeds
{
    public static class SensorTypeSeed
    {
        public static IEnumerable<SensorType> GetData()
        {
            return new List<SensorType>
            {
                new SensorType { Id = 1, Type = SensorTypes.Temperature, MeasurementUnit = SensorTypes.Temperature.GetDescription()},
                new SensorType { Id = 2, Type = SensorTypes.Humidity, MeasurementUnit = SensorTypes.Humidity.GetDescription() },
                new SensorType { Id = 3, Type = SensorTypes.Sound, MeasurementUnit = SensorTypes.Sound.GetDescription() },
                new SensorType { Id = 4, Type = SensorTypes.Light, MeasurementUnit = SensorTypes.Light.GetDescription() },
                new SensorType { Id = 5, Type = SensorTypes.Co2, MeasurementUnit = SensorTypes.Co2.GetDescription() },
                new SensorType { Id = 6, Type = SensorTypes.Pir, MeasurementUnit = SensorTypes.Pir.GetDescription() }
            };
        }
    }
}