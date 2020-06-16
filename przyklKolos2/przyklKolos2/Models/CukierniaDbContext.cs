using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace przyklKolos2.Models
{
    public class CukierniaDbContext : DbContext
    {
        public DbSet<Klient> Klienci { get; set; }
        public DbSet<Pracownik> Pracownicy { get; set; }
        public DbSet<Zamowienie> Zamowienia { get; set; }
        public DbSet<WyrobCukierniczy> WyrobyCukiernicze { get; set; }
        public DbSet<Zamowienie_WyrobCukierniczy> Zamowienia_WyrobyCukiernicze { get; set; }
        public CukierniaDbContext()
        {

        }
        public CukierniaDbContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Klient>(opt =>
            {
                opt.HasKey(p => p.IdKlient);
                opt.Property(p => p.IdKlient)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Imie)
                .HasMaxLength(50)
                .IsRequired();

                opt.Property(p => p.Nazwisko)
                .HasMaxLength(60)
                .IsRequired();

                opt.HasMany(p => p.Zamowienia)
                .WithOne(p => p.Klient)
                .HasForeignKey(p => p.IdKlient);
            });

            modelBuilder.Entity<Pracownik>(opt =>
            {
                opt.HasKey(p => p.IdPracownik);
                opt.Property(p => p.IdPracownik)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Imie)
                .HasMaxLength(50)
                .IsRequired();

                opt.Property(p => p.Nazwisko)
                .HasMaxLength(60)
                .IsRequired();

                opt.HasMany(p => p.Zamowienia)
                .WithOne(p => p.Pracownik)
                .HasForeignKey(p => p.IdPracownik);
            });

            modelBuilder.Entity<Zamowienie>(opt =>
            {
                opt.HasKey(p => p.IdZamowienia);
                opt.Property(p => p.IdZamowienia)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Uwagi)
                .HasMaxLength(300);

                opt.HasMany(p => p.Zamowienia_WyrobyCukiernicze)
                .WithOne(p => p.Zamowienie)
                .HasForeignKey(p => p.IdZamowienia);

            });

            modelBuilder.Entity<Zamowienie_WyrobCukierniczy>(opt =>
            {
                opt.HasKey(p => new { p.IdWyrobuCukierniczego, p.IdZamowienia });
                
                opt.Property(p => p.Uwagi)
                .HasMaxLength(300);

            });

            modelBuilder.Entity<WyrobCukierniczy>(opt =>
            {
                opt.HasKey(p => p.IdWyrobuCukierniczego);
                opt.Property(p => p.IdWyrobuCukierniczego)
                .ValueGeneratedOnAdd();

                opt.Property(p => p.Nazwa)
                .HasMaxLength(200)
                .IsRequired();

                opt.Property(p => p.Typ)
                .HasMaxLength(40)
                .IsRequired();

                opt.HasMany(p => p.Zamowienia_WyrobyCukiernicze)
                .WithOne(p => p.WyrobCukierniczy)
                .HasForeignKey(p => p.IdWyrobuCukierniczego);
            });
        }
    }
}
