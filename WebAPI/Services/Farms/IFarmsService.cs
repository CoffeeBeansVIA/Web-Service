using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database.DTOs;

namespace WebAPI.Services.Farms
{
    public interface IFarmsService
    {
        Task<FarmDetailDto> GetFarmByEUI(string EUI);
        Task<FarmDetailDto> GetFarmByIdAsync(int farmId);
        Task<IList<FarmDetailDto>> GetAllFarmsAsync();
        Task RemoveFarmByIdAsync(int farmId);
        Task CreateFarmAsync(FarmDto farm);
    }
}