using System.Threading.Tasks;
using WebAPI.Database.Models;

namespace WebAPI.Services
{
    public interface IPlantKeeperService
    {
        Task<PlantKeeper> GetPlantKeeperByIdAsync(int plantKeeperId);
        Task RemovePlantKeeperByIdAsync(int plantKeeperId);
        Task CreatePlantKeeperAsync(PlantKeeper plantKeeper);
    }
}