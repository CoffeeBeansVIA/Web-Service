using System;
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
        
        // public async Task<SensorSettings> GetSensorSettingsAsync(int sensorId)
        // {
        //     var foundSensor = _dataContext.Sensor.Find(sensorId);
        //     
        //     if (foundSensor == null)
        //         throw new NullReferenceException();
        //     
        //     await _dataContext.SensorSettingses.
        // }
        public Task<SensorSetting> GetSensorSettingsAsync(int sensorId)
        {
            throw new NotImplementedException();
        }

        public async Task<SensorSetting> UpdateSensorSettingsAsync(SensorSetting sensorSetting)
        {
            var foundSensor = _dataContext.Sensor.Where(s => s.Id == sensorSetting.SensorId).Include(s => s.SensorSetting).SingleOrDefault();

            if (foundSensor == null)
                throw new NullReferenceException();
            
            // If sensor's settings weren't previously set
            foundSensor.SensorSetting ??= new SensorSetting();

            foundSensor.SensorSetting.DesiredValue = sensorSetting.DesiredValue;
            foundSensor.SensorSetting.DeviationValue = sensorSetting.DeviationValue;
            _dataContext.SensorSettings.Update(foundSensor.SensorSetting);
            await _dataContext.SaveChangesAsync();

            return foundSensor.SensorSetting;
        }
    }
}