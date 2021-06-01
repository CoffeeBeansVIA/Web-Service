using System;
using WebAPI.Database.Models;

namespace WebAPI.Database.DTOs
{
    public class SensorDto : BaseModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
    }

    public class SensorDetailDto : BaseModel
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public SensorSettingDto SensorSetting { get; set; }
    }
}