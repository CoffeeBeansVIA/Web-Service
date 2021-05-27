using System.Collections.Generic;

namespace WebAPI.Database.Models
{
    public class PlantKeeper : BaseModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        
        public ICollection<Farm> Farms { get; set; }
    }
}