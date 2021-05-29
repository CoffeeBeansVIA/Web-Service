using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Database.DTOs;
using WebAPI.Database.Models;
using WebAPI.Services.PlantKeepers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlantKeepersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPlantKeepersService _plantKeepersService;

        public PlantKeepersController(IMapper mapper, IPlantKeepersService plantKeepersService)
        {
            _mapper = mapper;
            _plantKeepersService = plantKeepersService;
        }

        [HttpPost]
        public async Task<IActionResult> AddPlantKeeper(PlantKeeperDto plantKeeperToCreate)
        {
            var createdPlantKeeper =
                await _plantKeepersService
                    .AddPlantKeeperAsync(_mapper.Map<PlantKeeper>(plantKeeperToCreate));
            
            return Ok(_mapper.Map<PlantKeeperDto>(createdPlantKeeper));
        }
        
        [HttpGet("{plantKeeperId}")]
        public async Task<IActionResult> GetPlantKeeper(int plantKeeperId)
        {
            try
            {
                var foundPlantKeeper = await _plantKeepersService
                    .GetPlantKeeperByIdAsync(plantKeeperId);
                
                return Ok(_mapper.Map<PlantKeeperDetailDto>(foundPlantKeeper));
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{plantKeeperId}")]
        public async Task<IActionResult> RemovePlantKeeper(int plantKeeperId)
        {
            try
            {
                await _plantKeepersService.RemovePlantKeeperByIdAsync(plantKeeperId);
                
                return NoContent();
            }
            catch (NullReferenceException)
            {
                return NotFound();
            }
        }
    }
}