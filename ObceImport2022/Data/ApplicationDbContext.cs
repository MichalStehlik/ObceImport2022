using Microsoft.EntityFrameworkCore;
using ObceImport2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObceImport2022.Data
{
    internal class ApplicationDbContext : DbContext
    {
        string _connectionString;

        public DbSet<Region> Regions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Population> Populations { get; set; }

        public ApplicationDbContext() : base()
        {
            _connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CZPopulation;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Population>().HasKey(p => new { p.LAU2, p.Year });
            modelBuilder.Entity<Population>().ToTable("Populations");
            
            modelBuilder.Entity<Region>(entity =>
            {
                entity.HasMany(r => r.Districts).WithOne(r => r.Region).HasForeignKey(r => r.NUTS3).OnDelete(DeleteBehavior.NoAction);
                entity.HasOne(r => r.Capital).WithOne(m => m.CapitalOf).OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
