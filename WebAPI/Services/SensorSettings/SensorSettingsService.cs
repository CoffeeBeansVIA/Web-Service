using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Models.DTOs;

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
        public Task<SensorSettingDto> GetSensorSettingsAsync(int sensorId)
        {
            throw new NotImplementedException();
        }

        public async Task<SensorSettingDto> UpdateSensorSettingsAsync(SensorSettingDto sensorSetting)
        {
            var foundSensor = _dataContext.Sensor.Where(s => s.Id == sensorSetting.SensorId)
                .Include(s => s.SensorSetting).SingleOrDefault();

            if (foundSensor == null)
                throw new NullReferenceException();

            // If sensor's settings weren't previously set
            var sensorSettingDto = new SensorSettingDto()
            {
                DesiredValue = foundSensor.SensorSetting.DesiredValue,
                DeviationValue = foundSensor.SensorSetting.DeviationValue,
                SensorId = foundSensor.SensorSetting.SensorId
            };

            foundSensor.SensorSetting.DesiredValue = sensorSetting.DesiredValue;
            foundSensor.SensorSetting.DeviationValue = sensorSetting.DeviationValue;
            _dataContext.SensorSettings.Update(foundSensor.SensorSetting);
            await _dataContext.SaveChangesAsync();

            return sensorSettingDto;
        }

        public async Task<ActionResult<SensorSettingDto>> GetSensorSettingsByIdAsync(int sensorId)
        {
            var foundSensor = await _dataContext.Sensor
                .Select(s=> new SensorDetailDto()
                {
                    Id = s.Id,
                    SensorSetting = s.SensorSetting != null
                        ? new SensorSettingDto()
                        {
                            DesiredValue = s.SensorSetting.DesiredValue,
                            DeviationValue = s.SensorSetting.DeviationValue
                        }
                        : null
                }).SingleOrDefaultAsync(s => s.Id == sensorId);
            if (foundSensor == null)
            {
                throw new NullReferenceException();
            }

            return foundSensor.SensorSetting;
        }
    }
}