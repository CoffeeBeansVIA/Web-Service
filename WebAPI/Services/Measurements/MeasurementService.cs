using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Models.Models;
using WebAPI.Models.DTOs;

namespace WebAPI.Services.Measurements
{
    public class MeasurementService : IMeasurementsService
    {
        private readonly DataContext _dataContext;
        private readonly Random _random = new Random();

        public MeasurementService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        
        public async Task<IList<MeasurementDto>> GetSensorMeasurementsAsync(int sensorId, int limit)
        {
            var list = await _dataContext.Measurement.Where(m => m.SensorId == sensorId).OrderByDescending(m => m.Time).Take(limit).Reverse().ToListAsync();

            return list.Select(m => new MeasurementDto
            {
                Id = m.Id,
                Time = m.Time,
                Date = m.Date,
                Value = m.Value,
                SensorId = m.SensorId,
                Sensor = new SensorDto()
                {
                    Id = m.Sensor.Id,
                    Model = m.Sensor.Model,
                    Type = m.Sensor.SensorType.Type,
                }
            }).ToList();
        }
        
        public async Task<MeasurementDto> AddMeasurementAsync(MeasurementDto measurementDto)
        {
            var measurement = new Measurement()
            {
                Id = measurementDto.Id,
                Time = measurementDto.Time,
                Date = measurementDto.Date,
                Value = measurementDto.Value,
                SensorId = measurementDto.SensorId,
                Sensor = new Sensor()
                {
                    Id = measurementDto.Sensor.Id,
                    Model = measurementDto.Sensor.Model,
                    SensorType = new SensorType()
                    {
                        Type = measurementDto.Sensor.Type
                    }
                }
            };
            
            await _dataContext.Measurement.AddAsync(measurement);
            await _dataContext.SaveChangesAsync();

            return measurementDto;
        }
        
        public async Task<MeasurementDto> GetRandomSensorMeasurementAsync(int sensorId)
        {
            var foundSensor = _dataContext.Sensor.Find(sensorId);

            if (foundSensor == null)
                throw new NullReferenceException();

            DateTime now = DateTime.Now;
            MeasurementDto measurementDto = new MeasurementDto() {Time = now.ToString("HH:mm:ss"), Date = now.ToString("d"), SensorId = sensorId};;
            
            if (foundSensor.SensorTypeId == 1)
                measurementDto.Value = Math.Round(GetRandomDecimal(23.5, 26.5), 1);
            else if (foundSensor.SensorTypeId == 2)
                measurementDto.Value = Math.Round(GetRandomDecimal(92, 96));
            else if (foundSensor.SensorTypeId == 5)
                measurementDto.Value = Math.Round(GetRandomDecimal(250, 350));

            var measurement = new Measurement()
            {
                Date = measurementDto.Date,
                Id = measurementDto.Id,
                Value = measurementDto.Value,
                SensorId = measurementDto.SensorId,
                Sensor = new Sensor()
                {
                    Id = measurementDto.Sensor.Id,
                    Model = measurementDto.Sensor.Model,
                    SensorType = new SensorType()
                    {
                        Type = measurementDto.Sensor.Type
                    }
                }
            };
            
            await _dataContext.Measurement.AddAsync(measurement);
            await _dataContext.SaveChangesAsync();

            return measurementDto;
        }
        
        private decimal GetRandomDecimal(double min, double max)
        {
            return new decimal(_random.NextDouble() * (max-min) + min);
        }
    }
}