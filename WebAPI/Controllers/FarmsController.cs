using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models.DTOs;
using WebAPI.Services.Farms;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IFarmsService _farmsService;

        public FarmsController(IFarmsService farmsService)
        {
            _farmsService = farmsService;
        }
        
        [HttpGet("{farmId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFarm(int farmId)
        {
            var foundFarm = await _farmsService.GetFarmByIdAsync(farmId);

            if (foundFarm == null)
                return NotFound();

            return Ok(foundFarm);
        }

        [HttpGet]
        public async Task<ActionResult<IList<FarmDetailDto>>> GetFarms()
        {
            try
            {
                return Ok(await _farmsService.GetAllFarmsAsync());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpDelete("{farmId}")]
        public async Task<IActionResult> RemoveFarm(int farmId)
        {
            try
            {
                await _farmsService.RemoveFarmByIdAsync(farmId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateFarm(FarmDto farm)
        {
            try
            {
                await _farmsService.CreateFarmAsync(farm);
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