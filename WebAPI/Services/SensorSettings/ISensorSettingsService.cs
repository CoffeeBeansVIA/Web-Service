using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database.Models;

namespace WebAPI.Services.SensorSettings
{
    public interface ISensorSettingsService
    {
        Task<SensorSetting> GetSensorSettingsByIdAsync(int sensorId);
        Task RemoveSensorSettingsByIdAsync(int sensorId);
        Task<SensorSetting> UpdateSensorSettingsAsync(int sensorId, SensorSetting sensorSetting);
        Task UpdateMultipleSensorSettingsAsync(IEnumerable<Sensor> multipleSensors);
    }
}