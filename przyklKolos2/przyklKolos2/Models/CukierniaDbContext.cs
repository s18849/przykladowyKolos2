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
    }
}
