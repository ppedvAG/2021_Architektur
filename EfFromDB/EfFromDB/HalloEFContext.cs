using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EfFromDB
{
    public partial class HalloEFContext : DbContext
    {
        public HalloEFContext()
        {
        }

        public HalloEFContext(DbContextOptions<HalloEFContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Person> People { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=HalloEF");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.MitarbeiterId, "IX_Customers_MitarbeiterId");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Customer)
                    .HasForeignKey<Customer>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Mitarbeiter)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.MitarbeiterId);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasMany(d => d.Mitarbeiters)
                    .WithMany(p => p.Abteilungens)
                    .UsingEntity<Dictionary<string, object>>(
                        "AbteilungMitarbeiter",
                        l => l.HasOne<Employee>().WithMany().HasForeignKey("MitarbeiterId"),
                        r => r.HasOne<Department>().WithMany().HasForeignKey("AbteilungenId"),
                        j =>
                        {
                            j.HasKey("AbteilungenId", "MitarbeiterId");

                            j.ToTable("AbteilungMitarbeiter");

                            j.HasIndex(new[] { "MitarbeiterId" }, "IX_AbteilungMitarbeiter_MitarbeiterId");
                        });
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Beruf).HasMaxLength(86);

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Employee)
                    .HasForeignKey<Employee>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.Property(e => e.Werkljnwekljfn).HasColumnName("werkljnwekljfn");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
