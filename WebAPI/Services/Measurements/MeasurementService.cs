using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Models;

namespace WebAPI.Services.Measurements
{
    public class MeasurementService : IMeasurementsService
    {
        private readonly DataContext _dataContext;
        private readonly Random _random = new Random();

        public MeasurementService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Measurement> AddMeasurementAsync(int sensorId, Measurement measurement)
        {
            await DbFindSensorThrowableAsync(sensorId);

            measurement.SensorId = sensorId;

            return await DbAddMeasurementAsync(measurement);
        }

        public async Task<IEnumerable<Measurement>> GetSensorMeasurementsAsync(int sensorId, int limit)
        {
            await DbFindSensorThrowableAsync(sensorId);
            
            return await _dataContext.Measurement
                .Where(m => m.SensorId == sensorId)
                .OrderByDescending(m => m.Time)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<IEnumerable<Measurement>> GetSensorMeasurementsBetweenDatesAsync(int sensorId, DateTime from, DateTime to, int limit = 5)
        {
            await DbFindSensorThrowableAsync(sensorId);

            return await _dataContext.Measurement
                .Where(m => m.Time >= from && m.Time <= to)
                .OrderByDescending(m => m.Time)
                .Take(limit)
                .ToListAsync();
        }

        public async Task<Measurement> GetRandomValueSensorMeasurementAsync(int sensorId)
        {
            var foundSensor = await DbFindSensorThrowableAsync(sensorId);

            var randomMeasurement = new Measurement
            {
                Time = DateTime.Now,
                SensorId = sensorId
            };

            randomMeasurement.Value = foundSensor.SensorTypeId switch
            {
                1 => GetRandomInt(23, 26),
                2 => GetRandomInt(92, 96),
                5 => GetRandomInt(250, 350),
                _ => randomMeasurement.Value
            };

            return await DbAddMeasurementAsync(randomMeasurement);
        }

        private async Task<Measurement> DbAddMeasurementAsync(Measurement measurement)
        {
            await _dataContext.Measurement.AddAsync(measurement);
            await _dataContext.SaveChangesAsync();

            return measurement;
        }

        private async Task<Sensor> DbFindSensorThrowableAsync(int sensorId)
        {
            var foundSensor = await DbFindSensorAsync(sensorId);

            if (foundSensor == null)
                throw new NullReferenceException();

            return foundSensor;
        }

        private async Task<Sensor> DbFindSensorAsync(int sensorId)
        {
            return await _dataContext.Sensor.FindAsync(sensorId);
        }
        
        private int GetRandomInt(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}