using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Models;

namespace RentACar.Data.Seeds
{
    public class ArabaSeed : IEntityTypeConfiguration<Araba>
    {
        public void Configure(EntityTypeBuilder<Araba> builder)
        {
            builder.HasData(
                new Araba
                {
                    ArabaID = 1,
                    Plaka = "43HD101",
                    Marka = "Tofaş",
                    Model = "Doğan",
                    UretimYili = 1995,
                    YakitTuru = "Benzin",
                    EhliyetSinifi = "B",
                    KoltukSayisi = 5,
                    GunlukUcret = 50,
                    FirmaID = 1
                },
                new Araba
                {
                    ArabaID = 2,
                    Plaka = "43HD102",
                    Marka = "Tofaş",
                    Model = "Şahin",
                    UretimYili = 1995,
                    YakitTuru = "Benzin",
                    EhliyetSinifi = "B",
                    KoltukSayisi = 5,
                    GunlukUcret = 50,
                    FirmaID = 1
                },
                new Araba
                {
                    ArabaID = 3,
                    Plaka = "43HD103",
                    Marka = "Tofaş",
                    Model = "Kartal",
                    UretimYili = 1995,
                    YakitTuru = "Benzin",
                    EhliyetSinifi = "B",
                    KoltukSayisi = 5,
                    GunlukUcret = 50,
                    FirmaID = 1
                }
            );
        }
    }
}
