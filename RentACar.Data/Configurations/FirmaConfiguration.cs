using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Models;

namespace RentACar.Data.Configurations
{
    public class FirmaConfiguration : IEntityTypeConfiguration<Firma>
    {
        public void Configure(EntityTypeBuilder<Firma> builder)
        {
            builder.HasKey(x => x.FirmaID);
            builder.Property(x => x.FirmaID).UseIdentityColumn();
            builder.Property(x => x.Telefon).IsRequired();
            builder.Property(x => x.VergiNo).IsRequired();
            builder.ToTable("Firma");
        }
    }
}
