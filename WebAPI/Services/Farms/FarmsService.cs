using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.DTOs;
using WebAPI.Database.Models;

namespace WebAPI.Services.Farms
{
    public class FarmsService : IFarmsService
    {
        private readonly DataContext _dataContext;

        public FarmsService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<Farm> GetFarmByEUI(string eui)
        {
            return await _dataContext.Farm
                .Include(f => f.Sensors)
                .ThenInclude(s => s.SensorType)
                .Include(f => f.Sensors)
                .ThenInclude(s => s.SensorSetting)
                .Include(f => f.PlantKeepers)
                .FirstOrDefaultAsync(f => f.Eui == eui);
        }


        public async Task<Farm> GetFarmByIdAsync(int farmId)
        {
            return await _dataContext.Farm
                .Include(f => f.Sensors)
                .ThenInclude(s => s.SensorType)
                .Include(f => f.Sensors)
                .ThenInclude(s => s.SensorSetting)
                .Include(f => f.PlantKeepers)
                .FirstOrDefaultAsync(f => f.Id == farmId);
        }

        public async Task<IEnumerable<Farm>> GetAllFarmsAsync()
        {
            return await _dataContext.Farm
                .Include(f => f.Sensors)
                .ThenInclude(s => s.SensorType)
                .Include(f => f.Sensors)
                .ThenInclude(s => s.SensorSetting)
                .Include(f => f.PlantKeepers)
                .ToListAsync();
        }

        public async Task RemoveFarmByIdAsync(int farmId)
        {
            var farmToRemove = await _dataContext.Farm.FindAsync(farmId);
            if (farmToRemove == null)
                throw new NullReferenceException();

            _dataContext.Farm.Remove(farmToRemove);
            await _dataContext.SaveChangesAsync();
        }

        public async Task CreateFarmAsync(Farm farm)
        {
           farm.CreatedAt = farm.UpdatedAt = DateTime.Now;
           await _dataContext.Farm.AddAsync(farm);
           await _dataContext.SaveChangesAsync();
        }
    }
}