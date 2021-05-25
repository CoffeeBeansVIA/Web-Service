using System.Threading.Tasks;
using WebAPI.Models.DTOs;

namespace WebAPI.Services.SensorSettings
{
    public interface ISensorSettingsService
    {
        Task<SensorSettingDto> GetSensorSettingsAsync(int sensorId);
        Task<SensorSettingDto> UpdateSensorSettingsAsync(SensorSettingDto sensorSetting);
    }
}