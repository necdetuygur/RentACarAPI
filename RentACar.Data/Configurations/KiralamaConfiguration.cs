using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Models;

namespace RentACar.Data.Configurations
{
    public class KiralamaConfiguration : IEntityTypeConfiguration<Kiralama>
    {
        public void Configure(EntityTypeBuilder<Kiralama> builder)
        {
            builder.HasKey(x => x.KiralamaID);
            builder.Property(x => x.KiralamaID).UseIdentityColumn();
            builder.Property(x => x.AliciID).IsRequired();
            builder.Property(x => x.ArabaID).IsRequired();
            builder.Property(x => x.BaslangicTarihi).IsRequired();
            builder.Property(x => x.BitisTarihi).IsRequired();
            builder.ToTable("Kiralama");
        }
    }
}
