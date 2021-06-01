using System;
using AutoMapper;
using WebAPI.Database.DTOs;
using WebAPI.Database.Models;
using WebAPI.Database.Seeds;

namespace WebAPI.Database.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            // Measurement mapping
            CreateMap<Measurement, MeasurementDto>().ReverseMap();
            CreateMap<Measurement, MeasurementDetailDto>().ReverseMap();
            
            // Sensor mapping
            CreateMap<SensorDto, Sensor>()
                .ForMember(dest => dest.SensorTypeId,
                    opt => opt.MapFrom((src, dest) =>
                    {
                        if (!Enum.TryParse(typeof(SensorTypes), src.Type, out var parsedResult))
                            return (int) SensorTypes.Pir;

                        return (int) parsedResult;
                    }));
            
            CreateMap<Sensor, SensorDto>()
                .ForMember(dest => dest.Type,
                    opt =>
                        opt.MapFrom(src => src.SensorType.Type.ToString()))
                .ForMember(dest => dest.Unit,
                    opt =>
                        opt.MapFrom(src => src.SensorType.MeasurementUnit));
            
            CreateMap<Sensor, SensorDetailDto>()
                .ForMember(dest => dest.Type,
                    opt =>
                        opt.MapFrom(src => src.SensorType.Type))
                .ForMember(dest => dest.Unit,
                    opt =>
                        opt.MapFrom(src => src.SensorType.MeasurementUnit));

            CreateMap<SensorDetailDto, Sensor>();

            // Sensor settings mapping
            CreateMap<SensorSetting, SensorSettingDto>().ReverseMap();

            // Plant keeper mapping
            CreateMap<PlantKeeper, PlantKeeperDto>().ReverseMap();
            CreateMap<PlantKeeper, PlantKeeperDetailDto>().ReverseMap();
            
            // Farm mapping
            CreateMap<Farm, FarmDto>().ReverseMap();
            CreateMap<Farm, FarmDetailDto>().ReverseMap();
        }
    }
}