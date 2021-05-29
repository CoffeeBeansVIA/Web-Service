using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using Tests.Models;

namespace Tests
{
    public class SensorSettingsControllerTest
    {
        [Test]
        public async Task CreateSensorTest()
        {
            var sensor = new SensorSetting()
            {
                DesiredValue = 22,
                DeviationValue = 23
            };

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PutAsJsonAsync("http://localhost:5000/api//api/farms/1/sensors/1/settings", sensor))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }

        [Test]
        public async Task GetSensorSettingsTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/farms/1/sensors/1/settings"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }

        [Test]
        public async Task DeleteSensorSettingTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/farms/1/sensors/1/settings/2"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
    }
}