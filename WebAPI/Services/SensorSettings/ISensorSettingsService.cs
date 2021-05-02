using System.Threading.Tasks;
using WebAPI.Database.Models;

namespace WebAPI.Services.SensorSettings
{
    public interface ISensorSettingsService
    {
        Task<SensorSetting> GetSensorSettingsAsync(int sensorId);
        Task<SensorSetting> UpdateSensorSettingsAsync(SensorSetting sensorSetting);
    }
}