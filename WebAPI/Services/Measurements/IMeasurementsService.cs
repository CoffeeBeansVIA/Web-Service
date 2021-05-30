using System;  
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database.Models;

namespace WebAPI.Services.Measurements
{
    public interface IMeasurementsService
    {
        Task<Measurement> AddMeasurementAsync(int sensorId, Measurement measurement);
        Task<IEnumerable<Measurement>> GetSensorMeasurementsAsync(int sensorId, int limit);
        Task<IEnumerable<Measurement>> GetSensorMeasurementsBetweenDatesAsync(int sensorId, DateTime from, DateTime to, int limit);
        Task<Measurement> GetRandomValueSensorMeasurementAsync(int sensorId); // TODO remove on IoT connection 
        Task<IEnumerable<Measurement>> GetLastSensorsMeasurementAsync(int farmId);
    }
}