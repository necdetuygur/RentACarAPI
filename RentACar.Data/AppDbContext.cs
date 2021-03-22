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
        public DbSet<Alici> Alicis { get; set; }
        public DbSet<Firma> Firmas { get; set; }
        public DbSet<Kiralama> Kiralamas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArabaConfiguration());
            modelBuilder.ApplyConfiguration(new ArabaSeed());

            modelBuilder.ApplyConfiguration(new AliciConfiguration());
            modelBuilder.ApplyConfiguration(new AliciSeed());

            modelBuilder.ApplyConfiguration(new FirmaConfiguration());
            modelBuilder.ApplyConfiguration(new FirmaSeed());

            modelBuilder.ApplyConfiguration(new KiralamaConfiguration());
            modelBuilder.ApplyConfiguration(new KiralamaSeed());
        }
    }
}
