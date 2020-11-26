using Microsoft.EntityFrameworkCore;
using WebApplication.Data.Models;
using System;

namespace WebApplication.Data
{
    public class AppDBContent : DbContext
    {
        public AppDBContent(DbContextOptions<AppDBContent> options) : base(options) { }

        public DbSet<CarModel> CarModel { get; set; }
        public DbSet<CarTrim> CarTrim { get; set; }
        public DbSet<CarVariant> CarVariant { get; set; }
        public DbSet<CarOrder> CarOrder { get; set; }
        public DbSet<Customer> Customer { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarModel>()
                .HasIndex(c => c.Name)
                .IsUnique();

            modelBuilder.Entity<Customer>()
               .Property(c => c.Phone)
               .IsRequired()
               .HasMaxLength(8)
               .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasIndex(e => e.Email)
                .IsUnique();

            modelBuilder.Entity<CarOrder>()
                .Property(e => e.FuelType)
                .HasConversion<string>();
                    

            modelBuilder.Entity<CarOrder>()
                .Property(e => e.GearType)
                .HasConversion<string>();

            modelBuilder.Entity<CarVariant>()
                .Property(e => e.FuelType)
                .HasConversion<string>();

            modelBuilder.Entity<CarVariant>()
                .Property(e => e.GearType)
                .HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
