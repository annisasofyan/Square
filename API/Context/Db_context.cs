

using API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using System.Security.Principal;

namespace API.Context
{
    public class Db_context : DbContext
    {
        public Db_context(DbContextOptions<Db_context> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Mondems
            //  modelBuilder.Entity<MondemCalculate>().HasOne(ForeignEntity => ForeignEntity.Attend).WithMany(k => k.Mondems);Serrver 
            modelBuilder.Entity<WetherDetails>().HasOne(ForeignEntity => ForeignEntity.Weather).WithMany(k => k.WeatherDetails);
            modelBuilder.Entity<WetherDetails>().HasOne(ForeignEntity => ForeignEntity.City).WithMany(k => k.WeatherDetails);
            //Employee
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Square> Squares{ get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<WetherDetails> WetherDetails { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
