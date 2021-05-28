using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Database.DTOs;
using WebAPI.Database.Models;

namespace WebAPI.Services.Farms
{
    public interface IFarmsService
    {
        Task<Farm> GetFarmByEUI(string EUI);
        Task<FarmDetailDto> GetFarmByIdAsync(int farmId);
        Task<IEnumerable<Farm>> GetAllFarmsAsync();
        Task RemoveFarmByIdAsync(int farmId);
        Task CreateFarmAsync(Farm farm);
    }
}