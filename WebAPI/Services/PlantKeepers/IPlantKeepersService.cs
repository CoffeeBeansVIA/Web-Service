using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database.Models;

namespace WebAPI.Services.PlantKeepers
{
    public interface IPlantKeepersService
    {
        Task<PlantKeeper> AddPlantKeeperAsync(PlantKeeper plantKeeper);
        Task<PlantKeeper> GetPlantKeeperByIdAsync(int plantKeeperId);
        Task<IEnumerable<PlantKeeper>> GetAllFarmPlantKeepersAsync(int farmId);
        Task RemovePlantKeeperByIdAsync(int plantKeeperId);
    }
}