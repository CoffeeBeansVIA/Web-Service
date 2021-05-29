using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Tests.Models;

namespace Tests
{
    public class SensorControllerTest
    {
        [Test]
        public async Task CreateSensorTest()
        {
            var sensor = new Sensor()
            {
                Model = "X",
                Type = "x",
                Unit = "x"
            };

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/farms/1/sensors", sensor))
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
                
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/farms/1/sensors/4"))
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

        [Test]
        public async Task DeleteSensorTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/farms/1/sensors/4"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
    }
}