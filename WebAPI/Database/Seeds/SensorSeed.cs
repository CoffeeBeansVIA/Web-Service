using System.Collections.Generic;
using WebAPI.Database.Models;

namespace WebAPI.Database.Seeds
{
    public static class SensorSeed
    {
        public static IEnumerable<Sensor> GetData()
        {
            return new List<Sensor>
            {
                new Sensor { Id = 1, Model = "T1", FarmId = 1, SensorTypeId = 1 },
                new Sensor { Id = 2, Model = "H1", FarmId = 1, SensorTypeId = 2 },
                new Sensor { Id = 3, Model = "C1", FarmId = 1, SensorTypeId = 5 }
            };
        }
    }
}