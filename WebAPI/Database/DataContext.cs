using System;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database.Models;

// using Microsoft.EntityFrameworkCore;

namespace WebAPI.Database
{
    public class DataContext : DbContext
    {
        public DbSet<Farm> Farm { get; set; }
        public DbSet<Measurement> Measurement { get; set; }
        public DbSet<PlantKeeper> PlantKeeper { get; set; }
        public DbSet<Sensor> Sensor { get; set; }
        public DbSet<SensorType> SensorType { get; set; }

        public DataContext()
        {


    }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = Database.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sensor>()
                .HasOne<SensorType>(s => s.SensorType)
                .WithOne(st => st.Sensor)
                .HasForeignKey<SensorType>(ad => ad.SensorId);
        }

    }
}