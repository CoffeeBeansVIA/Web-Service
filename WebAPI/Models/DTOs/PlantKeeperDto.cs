using System.Collections.Generic;

namespace WebAPI.Models.DTOs
{
    public class PlantKeeperDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }

    public class PlantKeeperDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public IEnumerable<FarmDetailDto> Farms { get; set; }
    }
}