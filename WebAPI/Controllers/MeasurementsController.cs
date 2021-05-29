using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.DTOs;
using WebAPI.Database.Models;
using WebAPI.Services.Measurements;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/farms/{farmId}/sensors/{sensorId}/measurements")]
    public class MeasurementsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMeasurementsService _measurementsService;

        public MeasurementsController(IMapper mapper, IMeasurementsService measurementsService)
        {
            _mapper = mapper;
            _measurementsService = measurementsService;
        }
        
        [HttpPost]
        public async Task<IActionResult> AddSensorMeasurement(int sensorId, MeasurementDto measurementToCreate)
        {
            try
            {
                await _measurementsService
                    .AddMeasurementAsync(sensorId, _mapper.Map<Measurement>(measurementToCreate));
                
                return Ok();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MeasurementDto>>> GetSensorMeasurements(int sensorId, DateTime from, DateTime to, int limit = 5)
        {
            try
            {
                if (from != default && to != default && from >= to)
                    return BadRequest();
                
                IEnumerable<Measurement> foundMeasurements;

                if (from != default && to != default || to != default)
                    foundMeasurements = await _measurementsService.GetSensorMeasurementsBetweenDatesAsync(sensorId, from, to, limit);
                else if (from != default)
                    foundMeasurements = await _measurementsService.GetSensorMeasurementsBetweenDatesAsync(sensorId, from, DateTime.Now, limit);
                else
                    foundMeasurements = await _measurementsService.GetSensorMeasurementsAsync(sensorId, limit);
                
                return Ok(_mapper.Map<IEnumerable<MeasurementDto>>(foundMeasurements));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("randomMeasurements")]
        public async Task<IActionResult> GetRandomMeasurement(int sensorId)
        {
            try
            {
                var randomMeasurement = await _measurementsService
                    .GetRandomValueSensorMeasurementAsync(sensorId);
                
                return Ok(_mapper.Map<MeasurementDto>(randomMeasurement));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}