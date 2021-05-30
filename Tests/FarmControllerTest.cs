using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAPI.Database.DTOs;

namespace Tests
{
    public class FarmControllerTest
    {
        [Test]
        public async Task CreateAndDeleteFarmTest()
        {
            var farm = new FarmDto()
            {
                EUI = "X9999",
                Name = "Jensen",
                Location = "Horsens"
            };

            using (var httpClient = new HttpClient())
            {
                FarmDto _farm;
                using (var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/Farms", farm))
                {
                    _farm = response.Content.ReadFromJsonAsync<FarmDto>().Result;
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
                using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/Farms/"+_farm.Id))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }

        [Test]
        public async Task GetByEUIFarmTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/Farms/eui/0004A30B0021B92F"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }


        [Test]
        public async Task GetByIdFarmTest()
        {
            using (var httpClient = new HttpClient())
            {
                
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/Farms/1"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
        
        [Test]
        public async Task GetFarmsTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/Farms"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
    }
}