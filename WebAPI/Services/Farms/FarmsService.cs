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

        public async Task<FarmDetailDto> GetFarmByEUI(string eui)
        {
            var foundFarm = await _dataContext.Farm
                .Select(f => new FarmDetailDto
                {
                    Id = f.Id,
                    Eui = f.Eui,
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
                        // Type = s.SensorType.Type,
                        // Unit = s.Unit,
                        SensorSetting = s.SensorSetting != null ? new SensorSettingDto
                        {
                            DesiredValue = s.SensorSetting.DesiredValue,
                            DeviationValue = s.SensorSetting.DeviationValue
                        } : null
                    })
                }).SingleOrDefaultAsync(f => f.Eui == eui);

            return foundFarm;
        }

        public async Task<FarmDetailDto> GetFarmByIdAsync(int farmId)
        {
            var foundFarm = await _dataContext.Farm
                .Select(f => new FarmDetailDto
                {
                    Id = f.Id,
                    Eui = f.Eui,
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
                        // Type = s.SensorType.Type,
                        SensorSetting = s.SensorSetting != null ? new SensorSettingDto
                        {
                            DesiredValue = s.SensorSetting.DesiredValue,
                            DeviationValue = s.SensorSetting.DeviationValue
                        } : null
                    })
                }).SingleOrDefaultAsync(f => f.Id == farmId);

            return foundFarm;
        }

        public async Task<IList<FarmDetailDto>> GetAllFarmsAsync()
        {
            try
            {
                var list = await _dataContext.Farm.ToListAsync();
                var listDto = new List<FarmDetailDto>();

                foreach (var farm in list)
                {
                    var farmDto = new FarmDetailDto()
                    {
                        Id = farm.Id,
                        Eui = farm.Eui,
                        Name = farm.Name,
                        Location = farm.Location,
                        PlantKeepers = farm.PlantKeepers.Select(pk => new PlantKeeperDetailDto
                        {
                            Id = pk.Id,
                            FirstName = pk.FirstName,
                            LastName = pk.LastName,
                            Email = pk.Email,
                            DateOfBirth = pk.DateOfBirth,
                            Gender = pk.Gender
                        }),
                        Sensors = farm.Sensors.Select(s => new SensorDetailDto
                        {
                        Id = s.Id,
                        Model = s.Model,
                        // Type = s.SensorType.Type,
                        SensorSetting = s.SensorSetting != null ? new SensorSettingDto
                        {
                            DesiredValue = s.SensorSetting.DesiredValue,
                            DeviationValue = s.SensorSetting.DeviationValue
                        } : null
                        })
                    };
                    listDto.Add(farmDto);
                }
                return listDto;
            }
            catch (NullReferenceException)
            {
                return new List<FarmDetailDto>();
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
            }
        }

        public async Task CreateFarmAsync(FarmDto farmDto)
        {
            try
            {
                Farm farm = new Farm()
                {
                    Id = farmDto.Id,
                    Eui = farmDto.EUI,
                    Location = farmDto.Location,
                    Name = farmDto.Name,
                };
                await _dataContext.Farm.AddAsync(farm);
                await _dataContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}