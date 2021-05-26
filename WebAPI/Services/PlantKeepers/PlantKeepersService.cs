using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Models.Models;
using WebAPI.Models.DTOs;

namespace WebAPI.Services.PlantKeepers
{
    public class PlantKeepersService : IPlantKeepersService
    {
        private DataContext _dataContext;
        
        public PlantKeepersService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PlantKeeperDetailDto> GetPlantKeeperByIdAsync(int plantKeeperId)
        {
            try
            {
                var foundPlantKeeper = await _dataContext.PlantKeeper
                    .Select(pk => new PlantKeeperDetailDto
                    {
                        Id = pk.Id,
                        FirstName = pk.FirstName,
                        LastName = pk.LastName,
                        Email = pk.Email,
                        DateOfBirth = pk.DateOfBirth,
                        Gender = pk.Gender,
                        Farms = pk.Farms.Select(f => new FarmDetailDto
                        {
                            Id = f.Id,
                            Name = f.Name,
                            Location = f.Location
                        })
                    }).SingleOrDefaultAsync(pk => pk.Id == plantKeeperId);
                
                return foundPlantKeeper;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new PlantKeeperDetailDto();
            }
        }

        public async Task RemovePlantKeeperByIdAsync(int plantKeeperId)
        {
            try
            {
                var plantKeeperToRemove = await _dataContext.PlantKeeper.FindAsync(plantKeeperId);
                _dataContext.PlantKeeper.Remove(plantKeeperToRemove);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task CreatePlantKeeperAsync(PlantKeeperDto plantKeeperDto)
        {
            try
            {
                var plantKeeper = new PlantKeeper()
                {
                    Id = plantKeeperDto.Id,
                    FirstName = plantKeeperDto.FirstName,
                    LastName = plantKeeperDto.LastName,
                    Email = plantKeeperDto.Email
                };
                
                _dataContext.PlantKeeper.Add(plantKeeper);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}