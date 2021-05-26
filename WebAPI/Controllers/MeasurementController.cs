using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTOs;
using WebAPI.Services.Measurements;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementsService _measurementsService;

        public MeasurementController(IMeasurementsService measurementsService)
        {
            _measurementsService = measurementsService;
        }
        
        [HttpGet]
        [Route("~/api/sensors/{sensorId:int}/measurements")]
        public async Task<ActionResult<IList<MeasurementDto>>> GetSensorMeasurements(int sensorId, int limit = 5)
        {
            return Ok(await _measurementsService.GetSensorMeasurementsAsync(sensorId, limit));
        }

        [HttpGet]
        [Route("~/api/sensors/{sensorId:int}/randomMeasurements")]
        public async Task<IActionResult> GetRandomMeasurement(int sensorId)
        {
            try
            {
                return Ok(await _measurementsService.GetRandomSensorMeasurementAsync(sensorId));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
        
        [HttpPost]
        [Route("~/api/sensors/{sensorId:int}/measurements")]
        public async Task<IActionResult> AddSensorMeasurement(int sensorId, MeasurementDto measurement)
        {
            await _measurementsService.AddMeasurementAsync(measurement);

            return Ok();
        }
    }
}