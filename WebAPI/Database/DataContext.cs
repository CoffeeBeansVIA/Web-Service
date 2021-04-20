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
            modelBuilder.Entity<SensorType>().HasData(
                new SensorType() {Id = 1, Type = "Temperature"},
                new SensorType() {Id = 2, Type = "Humidity"},
                new SensorType() {Id = 3, Type = "Sound"},
                new SensorType() {Id = 4, Type = "Light"},
                new SensorType() {Id = 5, Type = "CO2"},
                new SensorType() {Id = 6, Type = "PIR"});
        }
    }
}