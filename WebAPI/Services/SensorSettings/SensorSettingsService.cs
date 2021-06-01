using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Models;

namespace WebAPI.Services.SensorSettings
{
    public class SensorSettingsService : ISensorSettingsService
    {
        private readonly DataContext _dataContext;

        public SensorSettingsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<SensorSetting> GetSensorSettingsByIdAsync(int sensorId)
        {
            var foundSensor = await _dataContext.Sensor
                .Include(s => s.SensorSetting)
                .FirstOrDefaultAsync(s => s.Id == sensorId);

            return foundSensor.SensorSetting;
        }

        public async Task<SensorSetting> UpdateSensorSettingsAsync(int sensorId, SensorSetting sensorSetting)
        {
            var foundSensor = await _dataContext.Sensor
                .Include(s => s.SensorSetting)
                .FirstOrDefaultAsync(s => s.Id == sensorId);

            if (foundSensor == null)
                throw new NullReferenceException();

            var time = DateTime.Now;

            if (foundSensor.SensorSetting == null)
                foundSensor.SensorSetting = new SensorSetting
                {
                    CreatedAt = time,
                    DesiredValue = sensorSetting.DesiredValue,
                    DeviationValue = sensorSetting.DeviationValue
                };
            
            foundSensor.SensorSetting.DesiredValue = sensorSetting.DesiredValue;
            foundSensor.SensorSetting.DeviationValue = sensorSetting.DeviationValue;
            foundSensor.SensorSetting.UpdatedAt = time;
            
            _dataContext.SensorSettings.Update(foundSensor.SensorSetting);
            await _dataContext.SaveChangesAsync();
            
            return foundSensor.SensorSetting;
        }
        
        public async Task UpdateMultipleSensorSettingsAsync(IEnumerable<Sensor> multipleSensors)
        {
            foreach (var sensor in multipleSensors)
            {
                await UpdateSensorSettingsAsync(sensor.Id, sensor.SensorSetting);
            }
        }

        public async Task RemoveSensorSettingsByIdAsync(int sensorId)
        {
            var foundSensor = await _dataContext.SensorSettings
                .Include(s => s.Sensor)
                .FirstOrDefaultAsync(s => s.SensorId == sensorId);

            if (foundSensor == null)
                throw new NullReferenceException();
            
            _dataContext.SensorSettings.Remove(foundSensor);
            await _dataContext.SaveChangesAsync();
        }
    }
}