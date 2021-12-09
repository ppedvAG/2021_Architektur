using Microsoft.EntityFrameworkCore;
using ppedv.Personenverwaltung.Model;

namespace ppedv.Personenverwaltung.Data.EfCore
{
    public class EfContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Abteilung> Abteilungen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Personenverwaltung_DEV;Trusted_Connection=true;trustservercertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Mitarbeiter>().ToTable("Mitarbeiter");
            modelBuilder.Entity<Kunde>().ToTable("Kunden");
            modelBuilder.Entity<Person>().ToTable("Personen");
        }
    }
}


