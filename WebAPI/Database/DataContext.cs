using Microsoft.EntityFrameworkCore;
using WebAPI.Database.Models;
using WebAPI.Database.Seeds;

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
            modelBuilder.Entity<SensorType>()
                .Property(st => st.Type)
                .HasConversion<string>();
            
            // Data seed
            modelBuilder.Entity<PlantKeeper>().HasData(PlantKeeperSeed.GetData());
            modelBuilder.Entity<Farm>().HasData(FarmSeed.GetData());
            modelBuilder.Entity<SensorType>().HasData(SensorTypeSeed.GetData());
            modelBuilder.Entity<Sensor>().HasData(SensorSeed.GetData());
            modelBuilder.Entity<SensorSetting>().HasData(SensorSettingSeed.GetData());
            modelBuilder.Entity<Measurement>().HasData(MeasurementSeed.GetData());

            // Create many-to-many relationship
            modelBuilder.Entity("FarmPlantKeeper")
                .HasData(new { FarmsId = 1, PlantKeepersId = 1 });
            
            base.OnModelCreating(modelBuilder);
        }
    }
}