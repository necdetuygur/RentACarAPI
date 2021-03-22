using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Models;

namespace RentACar.Data.Seeds
{
    public class AliciSeed : IEntityTypeConfiguration<Alici>
    {
        public void Configure(EntityTypeBuilder<Alici> builder)
        {
            builder.HasData(
                new Alici
                {
                    AliciID = 1,
                    Ad = "Melek",
                    Soyad = "Alper Atmaca",
                    TCKimlikNo = "22222222220",
                    CepTel = "05385161703",
                    Mail = "melekalperatmaca@gmail.com",
                    Adres = "Göztepe İzmir"
                },
                  new Alici
                  {
                      AliciID = 2,
                      Ad = "Necdet",
                      Soyad = "Uygur",
                      TCKimlikNo = "11111111110",
                      CepTel = "05462253671",
                      Mail = "necdet.uygur@gmail.com",
                      Adres = "Yeşilyurt İzmir"
                  },
                    new Alici
                    {
                        AliciID = 3,
                        Ad = "Ömer",
                        Soyad = "Dağdeviren",
                        TCKimlikNo = "44444444440",
                        CepTel = "05465675080",
                        Mail = "omerdgdvrn21@gmail.com",
                        Adres = "Bornova İzmir"
                    }
            );
        }
    }
}
