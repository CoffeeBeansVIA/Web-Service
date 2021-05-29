using System;
using System.Collections.Generic;
using WebAPI.Database.Models;
using WebAPI.Utils;

namespace WebAPI.Database.Seeds
{
    public static class PlantKeeperSeed
    {
        public static IEnumerable<PlantKeeper> GetData()
        {
            return new List<PlantKeeper>
            {
                new PlantKeeper
                {
                    Id = 1, FirstName = "John", LastName = "Smith", Email = "john.smith@coffee.com", HashPassword = "1",
                    Gender = "Male", DateOfBirth = "01/01/2000", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
                }
            };
        }
    }
}