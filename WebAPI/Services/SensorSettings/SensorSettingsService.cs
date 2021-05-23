using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Models;
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


        public async Task<SensorSetting> UpdateSensorSettingsAsync(SensorSetting sensorSetting)
        {
            var foundSensor = _dataContext.Sensor.Where(s => s.Id == sensorSetting.SensorId)
                .Include(s => s.SensorSetting).SingleOrDefault();

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