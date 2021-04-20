using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Models;

namespace WebAPI.Services
{
    public class FarmService : IFarmService
    {
        private readonly DataContext _dataContext;

        public FarmService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<Farm> GetFarmByIdAsync(int farmId)
        {
            try
            {
                return await _dataContext.Farm.FindAsync(farmId);
            }
            catch (NullReferenceException)
            {
                return new Farm();
            }
        }

        public async Task<List<Farm>> GetAllFarmsAsync()
        {
            try
            {
                return await _dataContext.Farm.ToListAsync();
            }
            catch (NullReferenceException)
            {
                return new List<Farm>();
            }
        }

        public async Task RemoveFarmByIdAsync(int farmId)
        {
            try
            {
                var farmToRemove = await _dataContext.Farm.FindAsync(farmId);
                _dataContext.Farm.Remove(farmToRemove);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task CreateFarmAsync(Farm farm)
        {
            try
            {
                _dataContext.Farm.Add(farm);
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