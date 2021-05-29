using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Tests.Models;

namespace Tests
{
    
    public class FarmControllerTest
    {
        #region Variables  
        private Farm _farm;
        #endregion 
        
        [Test, Order(1)]
        public async Task CreateFarmTest()
        {
            var farm = new Farm()
            {
                EUI = "X9999",
                Name = "Jensen",
                Location = "Horsens"
            };

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.PostAsJsonAsync("http://localhost:5000/api/Farms", farm))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    _farm = JsonConvert.DeserializeObject<Farm>(apiResponse);
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                    Assert.AreEqual(8, _farm.Id);
                }
            }
        }

        [Test, Order(2)]
        public async Task GetByEUIFarmTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/Farms/"+_farm.EUI))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }


        [Test, Order(3)]
        public async Task GetByIdFarmTest()
        {
            using (var httpClient = new HttpClient())
            {
                
                using (var response = await httpClient.GetAsync("http://localhost:5000/api/Farms/"+_farm.Id))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }
        
        [Test, Order(4)]
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

        [Test, Order(5)]
        public async Task DeleteFarmTest()
        {
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:5000/api/Farms/"+_farm.Id))
                {
                    Assert.AreEqual(true, response.IsSuccessStatusCode);
                }
            }
        }

    }
}