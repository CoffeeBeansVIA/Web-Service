using WebAPI.Database.Models;

namespace WebAPI.Database.DTOs
{
    public class SensorSettingDto : BaseModel
    {   
        public int Id { get; set; }
        public int DesiredValue { get; set; }
        public int DeviationValue { get; set; }
    }
}