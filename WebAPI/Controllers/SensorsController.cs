using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTOs;
using WebAPI.Services.Sensors;
using WebAPI.Services.SensorSettings;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorsService _sensorsService;
        private readonly ISensorSettingsService _sensorSettingsService;

        public SensorsController(ISensorsService sensorsService, ISensorSettingsService sensorSettingsService)
        {
            _sensorsService = sensorsService;
            _sensorSettingsService = sensorSettingsService;
        }

        [HttpGet("{sensorId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetSensorById(int sensorId)
        {
            var foundSensor = await _sensorsService.GetSensorByIdAsync(sensorId);

            if (foundSensor == null)
                return NotFound();

            return Ok(foundSensor);
        }

        [HttpPost]
        public async Task<ActionResult<SensorDto>> AddSensor([FromBody] SensorDto sensor)
        {
            await _sensorsService.AddSensorAsync(sensor);

            return sensor;
        }

        [HttpPut("{sensorId}/settings")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutSensorSettings(int sensorId, [FromBody] SensorSettingDto sensorSetting)
        {
            sensorSetting.SensorId = sensorId;
            
            try
            {
                await _sensorSettingsService.UpdateSensorSettingsAsync(sensorSetting);
                
                return Ok();
            }
            catch (NullReferenceException e)
            {
                return NotFound();
            }
        }
    }
}