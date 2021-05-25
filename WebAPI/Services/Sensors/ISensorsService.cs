using System.Threading.Tasks;
using WebAPI.Models.DTOs;

namespace WebAPI.Services.Sensors
{
    public interface ISensorsService
    {
        Task<SensorDetailDto> GetSensorByIdAsync(int sensorId);
        // public Task<IEnumerable<Sensor>> GetAllSensorsAsync();
        Task<SensorDto> AddSensorAsync(SensorDto sensor);
        // public Task<Sensor> UpdateSensorAsync(int id, Sensor sensor);
        // public Task<Sensor> DeleteSensorAsync(int id);
    }
}