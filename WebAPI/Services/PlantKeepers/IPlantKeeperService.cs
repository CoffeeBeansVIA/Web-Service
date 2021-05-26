using System.Threading.Tasks;
using WebAPI.Models.DTOs;

namespace WebAPI.Services.PlantKeepers
{
    public interface IPlantKeeperService
    {
        Task<PlantKeeperDetailDto> GetPlantKeeperByIdAsync(int plantKeeperId);
        Task RemovePlantKeeperByIdAsync(int plantKeeperId);
        Task CreatePlantKeeperAsync(PlantKeeperDto plantKeeper);
    }
}