using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAPI.Database.DTOs;

namespace Tests
{
    public class SensorControllerTest
    {
        [Test]
        public async Task CreateAndDeleteSensorTest()
        {
            var sensor = new SensorDto()
            {
                Model = "X",
                Type = "x",
                Unit = "x"
            };
            

            using (var httpClient = new HttpClient())
            {
                SensorDto _sensor;
                using (var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/farms/1/sensors", sensor))
                {
                    _sensor = response.Content.ReadFromJsonAsync<SensorDto>().Result;
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
                using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/farms/1/sensors/"+_sensor.Id))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }

        [Test]
        public async Task GetByIdSensorTest()
        {
            using (var httpClient = new HttpClient())
            {
                
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/farms/1/sensors/1"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
        
        [Test]
        public async Task GetSensorsTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/farms/1/sensors"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
    }
}