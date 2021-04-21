using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database.Models;

namespace WebAPI.Services
{
    public interface IMeasurementsService
    {
        Task<List<Measurement>> GetSensorMeasurementsAsync(int sensorId, int limit);
        Task<Measurement> AddMeasurementAsync(Measurement measurement);
    }
}