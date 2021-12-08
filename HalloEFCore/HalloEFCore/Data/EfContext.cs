using HalloEFCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HalloEFCore.Data
{
    internal class EfContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Abteilung> Abteilungen { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HalloEF;Trusted_Connection=true;trustservercertificate=true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Abteilung>().ToTable("Departments");
            modelBuilder.Entity<Mitarbeiter>().ToTable("Employees");
            modelBuilder.Entity<Kunde>().ToTable("Customers");
            modelBuilder.Entity<Person>().ToTable("People");

            modelBuilder.Entity<Mitarbeiter>().Property(x => x.Job)
                                              .HasColumnName("Beruf")
                                              .HasMaxLength(86)
                                              .IsRequired();
        }
    }
}
