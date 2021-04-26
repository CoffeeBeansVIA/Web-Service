using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    public class MeasurementController : ControllerBase
    {
        private readonly IMeasurementsService _measurementsService;

        public MeasurementController(IMeasurementsService measurementsService)
        {
            _measurementsService = measurementsService;
        }
        
        [HttpGet]
        [Route("api/sensors/{sensorId:int}/measurements")]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetSensorMeasurements(int sensorId, int limit = 5)
        {
            return await _measurementsService.GetSensorMeasurementsAsync(sensorId, limit);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Measurement))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Route("api/sensors/{sensorId:int}/randomMeasurements")]
        public async Task<IActionResult> GetRandomMeasurement(int sensorId)
        {
            try
            {
                return Ok(await _measurementsService.GetRandomSensorMeasurementAsync(sensorId));
            }
            catch (NullReferenceException e)
            {
                return NotFound();
            }
        }
    }
}