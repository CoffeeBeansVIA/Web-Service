using System;
using System.Collections.Generic;
using WebAPI.Database.Models;

namespace WebAPI.Database.Seeds
{
    public static class FarmSeed
    {
        public static IEnumerable<Farm> GetData()
        {
            return new List<Farm>
            {
                new Farm
                {
                    Id = 1, Eui = "0004A30B0021B92F", Name = "Lorem", Location = "Radhustorvet 4", CreatedAt = DateTime.Now, UpdatedAt = DateTime.Now
                }
            };
        }
    }
}