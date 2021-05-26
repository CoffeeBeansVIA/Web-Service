using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTOs;

namespace WebAPI.Services.SensorSettings
{
    public interface ISensorSettingsService
    {
        Task<SensorSettingDto> GetSensorSettingsAsync(int sensorId);
        Task<SensorSettingDto> UpdateSensorSettingsAsync(int sensorId, SensorSettingDto sensorSetting);
        Task<ActionResult<SensorSettingDto>> GetSensorSettingsByIdAsync(int sensorId);
}
}