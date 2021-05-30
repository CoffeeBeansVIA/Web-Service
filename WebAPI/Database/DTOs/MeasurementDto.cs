using System;

namespace WebAPI.Database.DTOs
{
    public class MeasurementDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
    }
    public class MeasurementDetailDto
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public DateTime Time { get; set; }
        public SensorDto Sensor { get; set; }
    }
}