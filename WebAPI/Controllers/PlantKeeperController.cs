using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTOs;
using WebAPI.Services.PlantKeepers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantKeeperController : ControllerBase
    {
        private readonly IPlantKeepersService _plantKeepersService;

        public PlantKeeperController(IPlantKeepersService plantKeepersService)
        {
            _plantKeepersService = plantKeepersService;
        }
        
        [HttpGet("{plantKeeperId}")]
        public async Task<ActionResult<PlantKeeperDetailDto>> GetPlantKeeper(int plantKeeperId)
        {
            try
            {
                return await _plantKeepersService.GetPlantKeeperByIdAsync(plantKeeperId);
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
                await _plantKeepersService.RemovePlantKeeperByIdAsync(plantKeeperId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlantKeeper(PlantKeeperDto plantKeeper)
        {
            try
            {
                await _plantKeepersService.CreatePlantKeeperAsync(plantKeeper);
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