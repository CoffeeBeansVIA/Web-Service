using System;
using System.Threading.Tasks;
using WebAPI.Database;
using WebAPI.Database.Models;

namespace WebAPI.Services
{
    public class PlantKeeperService : IPlantKeeperService
    {
        private DataContext _dataContext;
        
        public PlantKeeperService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<PlantKeeper> GetPlantKeeperByIdAsync(int plantKeeperId)
        {
            try
            {
                return await _dataContext.PlantKeeper.FindAsync(plantKeeperId);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return new PlantKeeper();
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

        public async Task CreatePlantKeeperAsync(PlantKeeper plantKeeper)
        {
            try
            {
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