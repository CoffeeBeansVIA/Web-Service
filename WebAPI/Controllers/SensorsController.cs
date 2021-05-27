using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.DTOs;
using WebAPI.Database.Models;
using WebAPI.Services.Sensors;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/farms/{farmId}/sensors")]
    public class SensorsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ISensorsService _sensorsService;
        
        public SensorsController(IMapper mapper, ISensorsService sensorsService)
        {
            _mapper = mapper;
            _sensorsService = sensorsService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddSensor(int farmId, SensorDto sensorToCreate)
        {
            var createdSensor = await _sensorsService.AddSensorAsync(farmId, _mapper.Map<Sensor>(sensorToCreate));
        
            return Ok(_mapper.Map<SensorDto>(createdSensor));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllFarmSensorsAsync(int farmId)
        {
            try
            {
                var foundSensors = await _sensorsService
                    .GetAllFarmSensorsAsync(farmId);

                if (foundSensors == null)
                    return NoContent();
            
                return Ok(_mapper.Map<IEnumerable<SensorDetailDto>>(foundSensors));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet("{sensorId}")]
        public async Task<IActionResult> GetSensorById(int sensorId)
        {
            var foundSensor = await _sensorsService.GetSensorByIdAsync(sensorId);

            if (foundSensor == null)
                return NotFound();
            
            return Ok(_mapper.Map<SensorDetailDto>(foundSensor));
        }
        
        [HttpDelete("{sensorId}")]
        public async Task<IActionResult> RemoveSensorById(int sensorId)
        {
            try
            {
                await _sensorsService.RemoveSensorByIdAsync(sensorId);
                
                return NoContent();
            }
            catch (NullReferenceException )
            {
                return NotFound();
            }
        }
    }
}