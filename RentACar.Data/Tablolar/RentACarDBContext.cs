using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace RentACar.Data.Tablolar
{
    public partial class RentACarDBContext : DbContext
    {
        public RentACarDBContext()
        {
        }

        public RentACarDBContext(DbContextOptions<RentACarDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Alici> Alicis { get; set; }
        public virtual DbSet<Araba> Arabas { get; set; }
        public virtual DbSet<Firma> Firmas { get; set; }
        public virtual DbSet<Kiralama> Kiralamas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=N-UYGUR;Database=RentACarDBFirst;User ID=sa;Password=Necdet2021;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Alici>(entity =>
            {
                entity.ToTable("Alici");

                entity.HasIndex(e => e.KiralamaId, "IX_Alici_KiralamaID");

                entity.Property(e => e.AliciId).HasColumnName("AliciID");

                entity.Property(e => e.CepTel).IsRequired();

                entity.Property(e => e.KiralamaId).HasColumnName("KiralamaID");

                entity.Property(e => e.Mail).IsRequired();

                entity.Property(e => e.TckimlikNo)
                    .IsRequired()
                    .HasColumnName("TCKimlikNo");

                entity.HasOne(d => d.Kiralama)
                    .WithMany(p => p.Alicis)
                    .HasForeignKey(d => d.KiralamaId);
            });

            modelBuilder.Entity<Araba>(entity =>
            {
                entity.ToTable("Araba");

                entity.HasIndex(e => e.FirmaId, "IX_Araba_FirmaID");

                entity.HasIndex(e => e.KiralamaId, "IX_Araba_KiralamaID");

                entity.Property(e => e.ArabaId).HasColumnName("ArabaID");

                entity.Property(e => e.FirmaId).HasColumnName("FirmaID");

                entity.Property(e => e.GunlukUcret).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.KiralamaId).HasColumnName("KiralamaID");

                entity.Property(e => e.Plaka).IsRequired();

                entity.HasOne(d => d.Firma)
                    .WithMany(p => p.Arabas)
                    .HasForeignKey(d => d.FirmaId);

                entity.HasOne(d => d.Kiralama)
                    .WithMany(p => p.Arabas)
                    .HasForeignKey(d => d.KiralamaId);
            });

            modelBuilder.Entity<Firma>(entity =>
            {
                entity.ToTable("Firma");

                entity.Property(e => e.FirmaId).HasColumnName("FirmaID");

                entity.Property(e => e.Telefon).IsRequired();

                entity.Property(e => e.VergiNo).IsRequired();
            });

            modelBuilder.Entity<Kiralama>(entity =>
            {
                entity.ToTable("Kiralama");

                entity.Property(e => e.KiralamaId).HasColumnName("KiralamaID");

                entity.Property(e => e.AliciId).HasColumnName("AliciID");

                entity.Property(e => e.ArabaId).HasColumnName("ArabaID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
