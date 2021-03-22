using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Models;

namespace RentACar.Data.Configurations
{
    public class ArabaConfiguration : IEntityTypeConfiguration<Araba>
    {
        public void Configure(EntityTypeBuilder<Araba> builder)
        {
            builder.HasKey(x => x.ArabaID);
            builder.Property(x => x.ArabaID).UseIdentityColumn();
            builder.Property(x => x.Plaka).IsRequired();
            builder.Property(x => x.GunlukUcret).HasColumnType("decimal");
            builder.ToTable("Araba");
        }
    }
}
