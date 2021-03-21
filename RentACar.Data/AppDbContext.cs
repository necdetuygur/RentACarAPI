using Microsoft.EntityFrameworkCore;
using RentACar.Core.Models;
using RentACar.Data.Configurations;
using RentACar.Data.Seeds;

namespace RentACar.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Araba> Arabas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArabaConfiguration());
            modelBuilder.ApplyConfiguration(new ArabaSeed());
        }
    }
}
