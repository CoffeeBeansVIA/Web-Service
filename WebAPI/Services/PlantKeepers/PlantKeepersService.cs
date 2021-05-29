using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.DTOs;
using WebAPI.Database.Models;

namespace WebAPI.Services.PlantKeepers
{
    public class PlantKeepersService : IPlantKeepersService
    {
        private readonly DataContext _dataContext;
        
        public PlantKeepersService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PlantKeeper> AddPlantKeeperAsync(PlantKeeper plantKeeper)
        {
            plantKeeper.CreatedAt = plantKeeper.UpdatedAt = DateTime.Now;

            await _dataContext.PlantKeeper.AddAsync(plantKeeper);
            await _dataContext.SaveChangesAsync();

            return await GetPlantKeeperByIdAsync(plantKeeper.Id);
        }

        public async Task<PlantKeeper> GetPlantKeeperByIdAsync(int plantKeeperId)
        {
            var foundPlantKeeper = await _dataContext.PlantKeeper
                .Include(pk => pk.Farms)
                .FirstOrDefaultAsync(pk => pk.Id == plantKeeperId);
            
            if (foundPlantKeeper == null)
                throw new NullReferenceException();

            return foundPlantKeeper;
        }

        public Task<IEnumerable<PlantKeeper>> GetAllFarmPlantKeepersAsync(int farmId)
        {
            throw new NotImplementedException();
        }

        public async Task RemovePlantKeeperByIdAsync(int plantKeeperId)
        {
            var foundPlantKeeper = await _dataContext.PlantKeeper.FindAsync(plantKeeperId);

            if (foundPlantKeeper == null)
                throw new NullReferenceException();
            
            _dataContext.PlantKeeper.Remove(foundPlantKeeper);
            await _dataContext.SaveChangesAsync();
        }
    }
}