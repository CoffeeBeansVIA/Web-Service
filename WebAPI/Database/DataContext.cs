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
        public DbSet<SensorSetting> SensorSettings { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed plant keeper
            PlantKeeper plantKeeper = new PlantKeeper()
            {
                Id = 1, FirstName = "John", LastName = "Smith", Email = "john.smith@coffee.com", HashPassword = "1",
                Gender = "Male", DateOfBirth = "01/01/2000"
            };
            modelBuilder.Entity<PlantKeeper>().HasData(plantKeeper);

            // Seed farm
            Farm farm = new Farm()
            {
                Id = 1, Name = "Lorem", Location = "Radhustorvet 4"
            };
            modelBuilder.Entity<Farm>().HasData(farm);

            modelBuilder.Entity("FarmPlantKeeper").HasData(
                new { FarmsId = 1, PlantKeepersId = 1 });

            // Seed sensor types
            modelBuilder.Entity<SensorType>().HasData(
                new SensorType() {Id = 1, Type = "Temperature"},
                new SensorType() {Id = 2, Type = "Humidity"},
                new SensorType() {Id = 3, Type = "Sound"},
                new SensorType() {Id = 4, Type = "Light"},
                new SensorType() {Id = 5, Type = "CO2"},
                new SensorType() {Id = 6, Type = "PIR"});
            
            // Seed sensors
            modelBuilder.Entity<Sensor>().HasData(
                new Sensor() {Id = 1, Model = "T1", Unit = "C", FarmId = 1, SensorTypeId = 1},
                new Sensor() {Id = 2, Model = "H1", Unit = "%", FarmId = 1, SensorTypeId = 2},
                new Sensor() {Id = 3, Model = "C1", Unit = "ppm", FarmId = 1, SensorTypeId = 5});
            
            // Seed sensor settings
            modelBuilder.Entity<SensorSetting>().HasData(
                new SensorSetting() {Id = 1, SensorId = 1, DesiredValue = 25, DeviationValue = 5});
            
            // Seed measurements
            modelBuilder.Entity<Measurement>().HasData(
                new Measurement() {Id = 1, Time = "15:50:58", Date = "20/04/2021", Value = 24.5m, SensorId = 1},
                new Measurement() {Id = 2, Time = "15:51:32", Date = "20/04/2021", Value = 24.4m, SensorId = 1},
                new Measurement() {Id = 3, Time = "15:52:49", Date = "20/04/2021", Value = 24.6m, SensorId = 1},
                new Measurement() {Id = 4, Time = "15:54:02", Date = "20/04/2021", Value = 24.7m, SensorId = 1},
                new Measurement() {Id = 5, Time = "15:55:48", Date = "20/04/2021", Value = 24.8m, SensorId = 1},
                new Measurement() {Id = 6, Time = "15:57:21", Date = "20/04/2021", Value = 24.7m, SensorId = 1},
                new Measurement() {Id = 7, Time = "15:58:19", Date = "20/04/2021", Value = 25.2m, SensorId = 1},
                new Measurement() {Id = 8, Time = "15:59:59", Date = "20/04/2021", Value = 25.4m, SensorId = 1},
                new Measurement() {Id = 9, Time = "15:50:58", Date = "20/04/2021", Value = 93, SensorId = 2},
                new Measurement() {Id = 10, Time = "15:51:32", Date = "20/04/2021", Value = 93, SensorId = 2},
                new Measurement() {Id = 11, Time = "15:52:49", Date = "20/04/2021", Value = 94, SensorId = 2},
                new Measurement() {Id = 12, Time = "15:54:02", Date = "20/04/2021", Value = 94, SensorId = 2},
                new Measurement() {Id = 13, Time = "15:55:48", Date = "20/04/2021", Value = 93, SensorId = 2},
                new Measurement() {Id = 14, Time = "15:57:21", Date = "20/04/2021", Value = 93, SensorId = 2},
                new Measurement() {Id = 15, Time = "15:58:19", Date = "20/04/2021", Value = 92, SensorId = 2},
                new Measurement() {Id = 16, Time = "15:59:59", Date = "20/04/2021", Value = 93, SensorId = 2},
                new Measurement() {Id = 17, Time = "15:50:58", Date = "20/04/2021", Value = 244, SensorId = 3},
                new Measurement() {Id = 18, Time = "15:51:32", Date = "20/04/2021", Value = 251, SensorId = 3},
                new Measurement() {Id = 19, Time = "15:52:49", Date = "20/04/2021", Value = 254, SensorId = 3},
                new Measurement() {Id = 20, Time = "15:54:02", Date = "20/04/2021", Value = 249, SensorId = 3},
                new Measurement() {Id = 21, Time = "15:55:48", Date = "20/04/2021", Value = 242, SensorId = 3},
                new Measurement() {Id = 22, Time = "15:57:21", Date = "20/04/2021", Value = 238, SensorId = 3},
                new Measurement() {Id = 23, Time = "15:58:19", Date = "20/04/2021", Value = 245, SensorId = 3},
                new Measurement() {Id = 24, Time = "15:59:59", Date = "20/04/2021", Value = 247, SensorId = 3}
                );
        }
    }
}