namespace WebAPI.Models.DTOs
{
    public class SensorDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
    }

    public class SensorDetailDto
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Unit { get; set; }
        public SensorSettingDto SensorSetting { get; set; }
    }
}