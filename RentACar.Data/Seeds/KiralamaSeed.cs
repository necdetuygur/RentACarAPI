using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Models;
using System;

namespace RentACar.Data.Seeds
{
    public class KiralamaSeed : IEntityTypeConfiguration<Kiralama>
    {
        public void Configure(EntityTypeBuilder<Kiralama> builder)
        {
            builder.HasData(
                new Kiralama
                {
                    KiralamaID = 1,
                    AliciID = 1,
                    ArabaID = 1,
                    BaslangicTarihi = DateTime.Parse("2021-01-01 00:00:00"),
                    BitisTarihi = DateTime.Parse("2021-02-01 00:00:00"),
                    TeslimTarihi = null
                },
                new Kiralama
                {
                    KiralamaID = 2,
                    AliciID = 2,
                    ArabaID = 2,
                    BaslangicTarihi = DateTime.Parse("2021-01-01 00:00:00"),
                    BitisTarihi = DateTime.Parse("2021-02-01 00:00:00"),
                    TeslimTarihi = null
                },
                new Kiralama
                {
                    KiralamaID = 3,
                    AliciID = 3,
                    ArabaID = 3,
                    BaslangicTarihi = DateTime.Parse("2021-01-01 00:00:00"),
                    BitisTarihi = DateTime.Parse("2021-02-01 00:00:00"),
                    TeslimTarihi = null
                }
            );
        }
    }
}
