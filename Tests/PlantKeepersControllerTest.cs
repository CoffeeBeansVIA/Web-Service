using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Tests.Models;

namespace Tests
{
    public class PlantKeepersControllerTest
    {
        [Test]
        public async Task CreateFarmTest()
        {
            var plantKeeper = new PlantKeeper()
            {
                FirstName = "John",
                LastName = "Jensen",
                Gender = "male",
                Email = "j@farmer.dk",
                DateOfBirth = "Unknown"
            };

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/PlantKeepers", plantKeeper))
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
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/PlantKeepers/2"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }

        [Test]
        public async Task DeletePlantKeeperTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/Farms/2"))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
    }
}