using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebAPI.Database.Models;
using WebAPI.Models.DTOs;

namespace WebAPI.Services
{
    public interface IFarmService
    {
        Task<FarmDetailDto> GetFarmByIdAsync(int farmId);
        Task<List<Farm>> GetAllFarmsAsync();
        Task RemoveFarmByIdAsync(int farmId);
        Task CreateFarmAsync(Farm farm);
    }
}