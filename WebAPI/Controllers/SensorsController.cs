using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.Models;
using WebAPI.Services.Sensors;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorsController : ControllerBase
    {
        private readonly ISensorsService _sensorsService;

        public SensorsController(ISensorsService sensorsService)
        {
            _sensorsService = sensorsService;
        }

        [HttpPost]
        public async Task<ActionResult<Sensor>> AddSensor([FromBody] Sensor sensor)
        {
            await _sensorsService.AddSensorAsync(sensor);

            return sensor;
        }
    }
}