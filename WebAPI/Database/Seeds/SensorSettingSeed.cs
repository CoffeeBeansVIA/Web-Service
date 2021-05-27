using System.Collections.Generic;
using WebAPI.Database.Models;

namespace WebAPI.Database.Seeds
{
    public static class SensorSettingSeed
    {
        public static IEnumerable<SensorSetting> GetData()
        {
            return new List<SensorSetting>
            {
                new SensorSetting { Id = 1, SensorId = 1, DesiredValue = 25, DeviationValue = 5 }
            };
        }
    }
}