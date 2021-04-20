using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantKeeperController : ControllerBase
    {
        private IPlantKeeperService _plantKeeperService;

        public PlantKeeperController(PlantKeeperService plantKeeperService)
        {
            _plantKeeperService = plantKeeperService;
        }
        
        [HttpGet("{plantKeeperId}")]
        public async Task<ActionResult<PlantKeeper>> GetPlantKeeper(int plantKeeperId)
        {
            try
            {
                return await _plantKeeperService.GetPlantKeeperByIdAsync(plantKeeperId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{plantKeeperId}")]
        public async Task<IActionResult> RemovePlantKeeper(int plantKeeperId)
        {
            try
            {
                await _plantKeeperService.RemovePlantKeeperByIdAsync(plantKeeperId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlantKeeper(PlantKeeper plantKeeper)
        {
            try
            {
                await _plantKeeperService.CreatePlantKeeperAsync(plantKeeper);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}