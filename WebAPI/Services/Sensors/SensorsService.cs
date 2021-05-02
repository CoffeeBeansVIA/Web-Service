using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Models;
using WebAPI.Models.DTOs;

namespace WebAPI.Services.Sensors
{
    public class SensorsService : ISensorsService
    {
        private readonly DataContext _dataContext;

        public SensorsService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<SensorDetailDto> GetSensorByIdAsync(int sensorId)
        {
            // return await _dataContext.Sensor.Where(s => s.Id == sensorId).Include(s => s.SensorSetting).Include(s => s.SensorType).FirstOrDefaultAsync();
            var foundSensor = await _dataContext.Sensor.Include(s => s.SensorSetting)
                .Include(s => s.SensorType)
                .Select(s => new SensorDetailDto
                {
                    Id = s.Id,
                    Model = s.Model,
                    Type = s.SensorType.Type,
                    Unit = s.Unit,
                    SensorSetting = new SensorSettingDto
                    {
                        desiredValue = s.SensorSetting.DesiredValue,
                        deviationValue = s.SensorSetting.DeviationValue
                    }
                    
                }).SingleOrDefaultAsync(s => s.Id == sensorId);

            return foundSensor;
        }

        public async Task<Sensor> AddSensorAsync(Sensor sensor)
        {
            try
            {
                 await _dataContext.Sensor.AddAsync(sensor);
                 await _dataContext.SaveChangesAsync();

                 return sensor;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}