using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.Models;
using WebAPI.Models.DTOs;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmsController : ControllerBase
    {
        private readonly IFarmService _farmService;

        public FarmsController(IFarmService farmService)
        {
            _farmService = farmService;
        }
        
        [HttpGet("{farmId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetFarm(int farmId)
        {
            var foundFarm = await _farmService.GetFarmByIdAsync(farmId);

            if (foundFarm == null)
                return NotFound();

            return Ok(foundFarm);
        }

        [HttpGet]
        public async Task<ActionResult<IList<Farm>>> GetFarms(int plantKeeperId)
        {
            try
            {
                return await _farmService.GetAllFarmsAsync();
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
                await _farmService.RemoveFarmByIdAsync(farmId);
                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        [HttpPost]
        public async Task<IActionResult> CreateFarm(Farm farm)
        {
            try
            {
                await _farmService.CreateFarmAsync(farm);
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