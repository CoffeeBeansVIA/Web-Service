using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAPI.Database.DTOs;


namespace Tests
{
    public class SensorSettingsControllerTest
    {
        [Test]
        public async Task CreateSensorTest()
        {
            var sensor = new SensorSettingDto()
            {
                DesiredValue = 22,
                DeviationValue = 23
            };

            using (var httpClient = new HttpClient())
            {
                SensorSettingDto setting;
                using (var response = await httpClient.PutAsJsonAsync("http://localhost:5000/api//api/farms/1/sensors/1/settings", sensor))
                {
                    setting = response.Content.ReadFromJsonAsync<SensorSettingDto>().Result;
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
                using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/farms/1/sensors/1/settings/"+setting.Id))
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
    }
}