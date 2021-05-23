using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Database.Models;
using WebAPI.Models.DTOs;

namespace WebAPI.Services
{
    public class FarmService : IFarmService
    {
        private readonly DataContext _dataContext;

        public FarmService(DataContext context)
        {
            _dataContext = context;
        }

        public async Task<FarmDetailDto> GetFarmByIdAsync(int farmId)
        {
            var foundFarm = await _dataContext.Farm
                .Select(f => new FarmDetailDto()
                {
                    Id = f.Id,
                    Name = f.Name,
                    Location = f.Location,
                    PlantKeepers = f.PlantKeepers.Select(pk => new PlantKeeperDetailDto
                    {
                        Id = pk.Id,
                        FirstName = pk.FirstName,
                        LastName = pk.LastName,
                        Email = pk.Email,
                        DateOfBirth = pk.DateOfBirth,
                        Gender = pk.Gender
                    }),
                    Sensors = f.Sensors.Select(s => new SensorDetailDto
                    {
                        Id = s.Id,
                        Model = s.Model,
                        Type = s.SensorType.Type,
                        Unit = s.Unit,
                        SensorSetting = s.SensorSetting != null ? new SensorSettingDto
                        {
                            DesiredValue = s.SensorSetting.DesiredValue,
                            DeviationValue = s.SensorSetting.DeviationValue
                        } : null
                    })
                }).SingleOrDefaultAsync(f => f.Id == farmId);

            return foundFarm;
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