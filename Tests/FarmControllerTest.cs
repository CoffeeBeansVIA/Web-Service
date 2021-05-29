using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using Tests.Models;

namespace Tests
{
    public class FarmControllerTest
    {
        [SetUp]
        public void Setup()
        {
            
        }
        
        
        [Test]
        public async Task GetByIdFarmTest()
        {
            var Base = "http://localhost:5000";
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Base+"/api/Farms/1"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<Farm>(apiResponse);
                    Assert.AreEqual("Lorem", result.Name);
                }
            }
        }
        
    }
}