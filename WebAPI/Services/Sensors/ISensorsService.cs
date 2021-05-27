using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database.Models;

namespace WebAPI.Services.Sensors
{
    public interface ISensorsService
    {
        Task<Sensor> AddSensorAsync(int farmId, Sensor sensor);
        Task<Sensor> GetSensorByIdAsync(int sensorId);
        Task<IEnumerable<Sensor>> GetAllFarmSensorsAsync(int farmId);
        Task RemoveSensorByIdAsync(int sensorId);
    }
}