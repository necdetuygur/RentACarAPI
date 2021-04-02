﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RentACar.Data.Tablolar;

namespace RentACar.Data.Migrations.RentACarDB
{
    [DbContext(typeof(RentACarDBContext))]
    partial class RentACarDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:Collation", "Turkish_CI_AS")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RentACar.Data.Tablolar.Alici", b =>
                {
                    b.Property<int>("AliciId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("AliciID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CepTel")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("KiralamaId")
                        .HasColumnType("int")
                        .HasColumnName("KiralamaID");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyad")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TckimlikNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TCKimlikNo");

                    b.HasKey("AliciId");

                    b.HasIndex(new[] { "KiralamaId" }, "IX_Alici_KiralamaID");

                    b.ToTable("Alici");
                });

            modelBuilder.Entity("RentACar.Data.Tablolar.Araba", b =>
                {
                    b.Property<int>("ArabaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ArabaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EhliyetSinifi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FirmaId")
                        .HasColumnType("int")
                        .HasColumnName("FirmaID");

                    b.Property<decimal>("GunlukUcret")
                        .HasColumnType("decimal(18,0)");

                    b.Property<int?>("KiralamaId")
                        .HasColumnType("int")
                        .HasColumnName("KiralamaID");

                    b.Property<int>("KoltukSayisi")
                        .HasColumnType("int");

                    b.Property<string>("Marka")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Plaka")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UretimYili")
                        .HasColumnType("int");

                    b.Property<string>("YakitTuru")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArabaId");

                    b.HasIndex(new[] { "FirmaId" }, "IX_Araba_FirmaID");

                    b.HasIndex(new[] { "KiralamaId" }, "IX_Araba_KiralamaID");

                    b.ToTable("Araba");
                });

            modelBuilder.Entity("RentACar.Data.Tablolar.Firma", b =>
                {
                    b.Property<int>("FirmaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("FirmaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adres")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Unvan")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("VergiNo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FirmaId");

                    b.ToTable("Firma");
                });

            modelBuilder.Entity("RentACar.Data.Tablolar.Kiralama", b =>
                {
                    b.Property<int>("KiralamaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("KiralamaID")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AliciId")
                        .HasColumnType("int")
                        .HasColumnName("AliciID");

                    b.Property<int>("ArabaId")
                        .HasColumnType("int")
                        .HasColumnName("ArabaID");

                    b.Property<DateTime>("BaslangicTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("BitisTarihi")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("TeslimTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("KiralamaId");

                    b.ToTable("Kiralama");
                });

            modelBuilder.Entity("RentACar.Data.Tablolar.Alici", b =>
                {
                    b.HasOne("RentACar.Data.Tablolar.Kiralama", "Kiralama")
                        .WithMany("Alicis")
                        .HasForeignKey("KiralamaId");

                    b.Navigation("Kiralama");
                });

            modelBuilder.Entity("RentACar.Data.Tablolar.Araba", b =>
                {
                    b.HasOne("RentACar.Data.Tablolar.Firma", "Firma")
                        .WithMany("Arabas")
                        .HasForeignKey("FirmaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("RentACar.Data.Tablolar.Kiralama", "Kiralama")
                        .WithMany("Arabas")
                        .HasForeignKey("KiralamaId");

                    b.Navigation("Firma");

                    b.Navigation("Kiralama");
                });

            modelBuilder.Entity("RentACar.Data.Tablolar.Firma", b =>
                {
                    b.Navigation("Arabas");
                });

            modelBuilder.Entity("RentACar.Data.Tablolar.Kiralama", b =>
                {
                    b.Navigation("Alicis");

                    b.Navigation("Arabas");
                });
#pragma warning restore 612, 618
        }
    }
}
