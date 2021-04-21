using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Models;

namespace WebAPI.Services
{
    public class MeasurementService : IMeasurementsService
    {
        private readonly DataContext _dataContext;
        private readonly Random _random = new Random();

        public MeasurementService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<List<Measurement>> GetSensorMeasurementsAsync(int sensorId, int limit)
        {
            return await _dataContext.Measurement.Where(m => m.SensorId == sensorId).OrderByDescending(m => m.Time).Take(limit).Reverse().ToListAsync();
        }

        public async Task<Measurement> AddMeasurementAsync(Measurement measurement)
        {
            await _dataContext.Measurement.AddAsync(measurement);
            await _dataContext.SaveChangesAsync();

            return measurement;
        }

        // Temporary
        public async Task<Measurement> GetRandomSensorMeasurementAsync(int sensorId)
        {
            var foundSensor = _dataContext.Sensor.Find(sensorId);

            if (foundSensor == null)
                throw new NullReferenceException();

            DateTime now = DateTime.Now;
            Measurement measurement = new Measurement() {Time = now.ToString("HH:mm:ss"), Date = now.ToString("d"), SensorId = sensorId};;
            
            if (foundSensor.SensorTypeId == 1)
                measurement.Value = Math.Round(GetRandomDecimal(23.5, 26.5), 1);
            else if (foundSensor.SensorTypeId == 2)
                measurement.Value = Math.Round(GetRandomDecimal(92, 96));
            else if (foundSensor.SensorTypeId == 5)
                measurement.Value = Math.Round(GetRandomDecimal(250, 350));


            await _dataContext.Measurement.AddAsync(measurement);
            await _dataContext.SaveChangesAsync();

            return measurement;
        }
        
        private decimal GetRandomDecimal(double min, double max)
        {
            return new decimal(_random.NextDouble() * (max-min) + min);
        }
    }
}