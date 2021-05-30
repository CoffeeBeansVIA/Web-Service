using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAPI.Database.DTOs;
using WebAPI.Database.Models;

namespace Tests
{
    public class MeasurementsController
    {
        [Test]
        public async Task CreateMeasurement()
        {
            var measurement = new MeasurementDto()
            {
                Value = 22
            };

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/farms/1/sensors/1/measurements", measurement))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
        
        [Test]
        public async Task GetLastSensorMeasurementTest()
        {
            var measurement = new MeasurementDto()
            {
                Value = 22
            };
            
            using (var httpClient = new HttpClient())
            {
                MeasurementDto _measurement;
                using (var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/farms/1/sensors/1/measurements", measurement))
                {
                    _measurement = response.Content.ReadFromJsonAsync<MeasurementDto>().Result;
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/farms/1/lastSensorsMeasurement"))
                {
                    var lastMeasurement = response.Content.ReadFromJsonAsync<MeasurementDto>().Result;
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                    Assert.AreEqual(_measurement.Value, lastMeasurement.Value);
                }
            }
        }
        
        
        [Test]
        public async Task GetMeasurementsTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/farms/1/sensors/1/measurements"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
        
    }
}