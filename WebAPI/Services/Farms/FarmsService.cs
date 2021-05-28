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


        public async Task<FarmDetailDto> GetFarmByIdAsync(int farmId)
        {
            // var foundFarm = await _dataContext.Farm
            //     .Select(f => new FarmDetailDto
            //     {
            //         Id = f.Id,
            //         Eui = f.Eui,
            //         Name = f.Name,
            //         Location = f.Location,
            //         PlantKeepers = f.PlantKeepers.Select(pk => new PlantKeeperDetailDto
            //         {
            //             Id = pk.Id,
            //             FirstName = pk.FirstName,
            //             LastName = pk.LastName,
            //             Email = pk.Email,
            //             DateOfBirth = pk.DateOfBirth,
            //             Gender = pk.Gender
            //         }),
            //         Sensors = f.Sensors.Select(s => new SensorDetailDto
            //         {
            //             Id = s.Id,
            //             Model = s.Model,
            //             // Type = s.SensorType.Type,
            //             SensorSetting = s.SensorSetting != null ? new SensorSettingDto
            //             {
            //                 DesiredValue = s.SensorSetting.DesiredValue,
            //                 DeviationValue = s.SensorSetting.DeviationValue
            //             } : null
            //         })
            //     }).SingleOrDefaultAsync(f => f.Id == farmId);

            return null;
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