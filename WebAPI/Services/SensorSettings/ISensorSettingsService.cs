using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.Models;
using WebAPI.Models.DTOs;

namespace WebAPI.Services.SensorSettings
{
    public interface ISensorSettingsService
    {
        Task<SensorSetting> UpdateSensorSettingsAsync(SensorSetting sensorSetting);
        Task<ActionResult<SensorSettingDto>> GetSensorSettingsByIdAsync(int sensorId);
    }
}