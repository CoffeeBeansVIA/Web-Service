using System;
using System.Threading.Tasks;
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