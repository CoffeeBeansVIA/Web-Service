using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : ControllerBase
    {
        private IFarmService _farmService;

        public FarmController(IFarmService farmService)
        {
            _farmService = farmService;
        }

        [HttpGet("{farmId}")]
        public async Task<ActionResult<Farm>> GetFarm(int farmId)
        {
            try
            {
                return await _farmService.GetFarmByIdAsync(farmId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
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