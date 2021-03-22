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
                    Plaka = "34FP8146",
                    Marka = "Wolksvagen",
                    Model = "Polo",
                    UretimYili = 2012,
                    YakitTuru = "Dizel",
                    EhliyetSinifi = "B",
                    KoltukSayisi = 5,
                    GunlukUcret = 150,
                    FirmaID = 2
                },
                new Araba
                {
                    ArabaID = 3,
                    Plaka = "35EHT84",
                    Marka = "Tofaş",
                    Model = "Şahin",
                    UretimYili = 2000,
                    YakitTuru = "Benzin",
                    EhliyetSinifi = "B",
                    KoltukSayisi = 5,
                    GunlukUcret = 75,
                    FirmaID = 3
                },
                new Araba
                {
                    ArabaID = 4,
                    Plaka = "35FST17",
                    Marka = "BMV",
                    Model = "1.16",
                    UretimYili = 2016,
                    YakitTuru = "Dizel",
                    EhliyetSinifi = "B",
                    KoltukSayisi = 5,
                    GunlukUcret = 200,
                    FirmaID = 2
                }
            );
        }
    }
}
