using System.Collections.Generic;
using WebAPI.Database.Models;

namespace WebAPI.Database.DTOs
{
    public class PlantKeeperDto : BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
    }

    public class PlantKeeperDetailDto : BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public IEnumerable<FarmDto> Farms { get; set; }
    }
}