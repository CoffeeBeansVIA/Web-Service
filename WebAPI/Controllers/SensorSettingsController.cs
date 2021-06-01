using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.DTOs;
using WebAPI.Database.Models;
using WebAPI.Services.SensorSettings;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/farms/{farmId}/sensors/{sensorId}/settings")]
    public class SensorSettingsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISensorSettingsService _sensorSettingsService;

        public SensorSettingsController(IMapper mapper, ISensorSettingsService sensorSettingsService)
        {
            _mapper = mapper;
            _sensorSettingsService = sensorSettingsService;
        }

        [HttpGet]
        public async Task<ActionResult<SensorSettingDto>> GetSensorSettings(int sensorId)
        {
            var sensorSettings = await _sensorSettingsService
                .GetSensorSettingsByIdAsync(sensorId);
            
            if (sensorSettings == null)
                return NotFound();

            return Ok(_mapper.Map<SensorSettingDto>(sensorSettings));
        }
        
        [HttpPut]
        public async Task<IActionResult> PutSensorSettings(int sensorId, SensorSettingDto sensorSetting)
        {
            try
            {
                var updatedSensorSettings = await _sensorSettingsService
                    .UpdateSensorSettingsAsync(sensorId, _mapper.Map<SensorSetting>(sensorSetting));
                
                return Ok(_mapper.Map<SensorSettingDto>(updatedSensorSettings));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
        
        [HttpPut]
        [Route("~/api/farms/{farmId}/sensors/settings")]
        public async Task<IActionResult> PutMultipleSensorSettings(IEnumerable<SensorDetailDto> sensorsSetting)
        {
            try
            {
                await _sensorSettingsService
                    .UpdateMultipleSensorSettingsAsync(_mapper.Map<IEnumerable<Sensor>>(sensorsSetting));
                
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteSensorSettings(int sensorId)
        {
            try
            {
                await _sensorSettingsService.RemoveSensorSettingsByIdAsync(sensorId);
                return NoContent();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}