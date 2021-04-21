using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic.CompilerServices;

namespace WebAPI.Database.Models
{
    public class PlantKeeper
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string HashPassword { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
    }
}