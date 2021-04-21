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
    }
}