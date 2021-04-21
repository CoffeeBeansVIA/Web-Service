using System.Threading.Tasks;
using WebAPI.Database.Models;

namespace WebAPI.Services.Sensors
{
    public interface ISensorsService
    {
        // public Task<Sensor> GetSensorByIdAsync();
        // public Task<IEnumerable<Sensor>> GetAllSensorsAsync();
        public Task<Sensor> AddSensorAsync(Sensor sensor);
        // public Task<Sensor> UpdateSensorAsync(int id, Sensor sensor);
        // public Task<Sensor> DeleteSensorAsync(int id);
    }
}