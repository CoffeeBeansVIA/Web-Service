using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using NUnit.Framework;
using WebAPI.Database.DTOs;

namespace Tests
{
    public class PlantKeepersControllerTest
    {
        [Test]
        public async Task CreateFarmTest()
        {
            var plantKeeper = new PlantKeeperDto()
            {
                FirstName = "John",
                LastName = "Jensen",
                Gender = "male",
                Email = "j@farmer.dk",
                DateOfBirth = "Unknown"
            };
            
            using (var httpClient = new HttpClient())
            {
                PlantKeeperDto _plantKeeper;
              
                using (var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/PlantKeepers", plantKeeper))
                {
                    _plantKeeper = response.Content.ReadFromJsonAsync<PlantKeeperDto>().Result;
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                    Assert.AreEqual(plantKeeper.Email, _plantKeeper.Email);
                }
                using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/PlantKeepers/"+_plantKeeper.Id))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
                
            }
        }
        
        [Test]
        public async Task GetByIdPlantKeeperTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/PlantKeepers/1"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
    }
}