using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Models;

namespace WebAPI.Services.Sensors
{
    public class SensorsService : ISensorsService
    {
        private readonly DataContext _dataContext;

        public SensorsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Sensor> AddSensorAsync(int farmId, Sensor sensor)
        {
            var foundFarm = await _dataContext.Farm.FindAsync(farmId);
            
            if (foundFarm == null)
                throw new NullReferenceException();

            sensor.FarmId = farmId;
            sensor.CreatedAt = sensor.UpdatedAt = DateTime.Now;

            await _dataContext.Sensor.AddAsync(sensor);
            await _dataContext.SaveChangesAsync();

            return await GetSensorByIdAsync(sensor.Id);
        }

        public async Task<Sensor> GetSensorByIdAsync(int sensorId)
        {
            var foundSensor = await _dataContext.Sensor
                .Include(s => s.SensorSetting)
                .Include(s => s.SensorType)
                .FirstOrDefaultAsync(s => s.Id == sensorId);

            return foundSensor;
        }

        public async Task<IEnumerable<Sensor>> GetAllFarmSensorsAsync(int farmId)
        {
            var foundFarm = await _dataContext.Farm.FindAsync(farmId);

            if (foundFarm == null)
                throw new NullReferenceException();
            
            var foundSensors = await _dataContext.Sensor
                .Include(s => s.SensorType)
                .Where(s => s.FarmId == farmId)
                .ToListAsync();

            return foundSensors;
        }

        public async Task RemoveSensorByIdAsync(int sensorId)
        {
            var foundSensor = await _dataContext.Sensor.FindAsync(sensorId);

            if (foundSensor == null)
                throw new NullReferenceException();
            
            _dataContext.Sensor.Remove(foundSensor);
            await _dataContext.SaveChangesAsync();
        }
    }
}