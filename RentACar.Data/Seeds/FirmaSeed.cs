using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Models;

namespace RentACar.Data.Seeds
{
    public class FirmaSeed : IEntityTypeConfiguration<Firma>
    {
        public void Configure(EntityTypeBuilder<Firma> builder)
        {
            builder.HasData(
                new Firma
                {
                    FirmaID = 1,
                    Unvan = "AtmacAlpers",
                    Telefon = "0535210",
                    Mail = "atmacalper@atmacalper.com",
                    Adres = "Göztepe",
                    VergiNo = "A123"
                },
                new Firma
                {
                    FirmaID = 2,
                    Unvan = "Uygurs",
                    Telefon = "0326569",
                    Mail = "uygurs@me.com",
                    Adres = "Yeşilyurt",
                    VergiNo = "Y125"
                },
                 new Firma
                 {
                     FirmaID = 3,
                     Unvan = "Dagdevirens",
                     Telefon = "0789542",
                     Mail = "dagdeviren@dagdeviren.com",
                     Adres = "Bornova",
                     VergiNo = "D567"
                 }
            );
        }
    }
}
