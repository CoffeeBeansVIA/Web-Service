using System;
using System.Collections.Generic;
using WebAPI.Database.Models;

namespace WebAPI.Database.Seeds
{
    public class MeasurementSeed
    {
        public static IEnumerable<Measurement> GetData()
        {
            return new List<Measurement>
            {
                new Measurement { Id = 1, Time = DateTime.Now, Value = 24, SensorId = 1 },
                new Measurement { Id = 2, Time = DateTime.Now, Value = 24, SensorId = 1 },
                new Measurement { Id = 3, Time = DateTime.Now, Value = 24, SensorId = 1 },
                new Measurement { Id = 4, Time = DateTime.Now, Value = 24, SensorId = 1 },
                new Measurement { Id = 5, Time = DateTime.Now, Value = 24, SensorId = 1 },
                new Measurement { Id = 6, Time = DateTime.Now, Value = 24, SensorId = 1 },
                new Measurement { Id = 7, Time = DateTime.Now, Value = 25, SensorId = 1 },
                new Measurement { Id = 8, Time = DateTime.Now, Value = 25, SensorId = 1 },
                new Measurement { Id = 9, Time = DateTime.Now,  Value = 93, SensorId = 2 },
                new Measurement { Id = 10, Time = DateTime.Now, Value = 93, SensorId = 2 },
                new Measurement { Id = 11, Time = DateTime.Now, Value = 94, SensorId = 2 },
                new Measurement { Id = 12, Time = DateTime.Now, Value = 94, SensorId = 2 },
                new Measurement { Id = 13, Time = DateTime.Now, Value = 93, SensorId = 2 },
                new Measurement { Id = 14, Time = DateTime.Now, Value = 93, SensorId = 2 },
                new Measurement { Id = 15, Time = DateTime.Now, Value = 92, SensorId = 2 },
                new Measurement { Id = 16, Time = DateTime.Now, Value = 93, SensorId = 2 },
                new Measurement { Id = 17, Time = DateTime.Now, Value = 244, SensorId = 3 },
                new Measurement { Id = 18, Time = DateTime.Now, Value = 251, SensorId = 3 },
                new Measurement { Id = 19, Time = DateTime.Now, Value = 254, SensorId = 3 },
                new Measurement { Id = 20, Time = DateTime.Now, Value = 249, SensorId = 3 },
                new Measurement { Id = 21, Time = DateTime.Now, Value = 242, SensorId = 3 },
                new Measurement { Id = 22, Time = DateTime.Now, Value = 238, SensorId = 3 },
                new Measurement { Id = 23, Time = DateTime.Now, Value = 245, SensorId = 3 },
                new Measurement { Id = 24, Time = DateTime.Now, Value = 247, SensorId = 3 }
            };
        }
    }
}