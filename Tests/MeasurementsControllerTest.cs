using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using WebAPI.Database.DTOs;

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
            var measurementToAdd = new MeasurementDto()
            {
                Value = 22
            };
            
            using (var httpClient = new HttpClient())
            {
                MeasurementDto measurement;
                using (var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/farms/1/sensors/1/measurements", measurementToAdd))
                {
                    measurement = response.Content.ReadFromJsonAsync<MeasurementDto>().Result;
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                    Assert.NotNull(measurement);
                }
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/farms/1/lastSensorsMeasurement"))
                {
                    var apiResponse = response.Content.ReadAsStringAsync().Result;
                    var lastMeasurements = JsonConvert.DeserializeObject<List<MeasurementDto>>(apiResponse);
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
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