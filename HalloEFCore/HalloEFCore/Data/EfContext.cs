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
        //public DbSet<Person> Persons { get; set; }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Mitarbeiter> Mitarbeiter { get; set; }
        public DbSet<Abteilung> Abteilungen { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HalloEF;Trusted_Connection=true;trustservercertificate=true");

        }

    }
}
