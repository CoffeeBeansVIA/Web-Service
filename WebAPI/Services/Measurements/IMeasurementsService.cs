using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Models.DTOs;

namespace WebAPI.Services.Measurements
{
    public interface IMeasurementsService
    {
        Task<IList<MeasurementDto>> GetSensorMeasurementsAsync(int sensorId, int limit);
        Task<MeasurementDto> AddMeasurementAsync(MeasurementDto measurement);
        Task<MeasurementDto> GetRandomSensorMeasurementAsync(int sensorId);
    }
}