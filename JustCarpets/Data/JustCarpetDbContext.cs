using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JustCarpets.Data
{
    public class JustCarpetDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        
            public JustCarpetDbContext(DbContextOptions<JustCarpetDbContext> options)
                : base(options)
            {
            }

            public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<CompanyLocationEntity> CompanyLocations { get; set; }
        public DbSet<InstallerRatesEntity> InstallerRates { get; set; }
        public DbSet<InstallerAppointmentsEntity> InstallerAppointments { get; set; }
        public DbSet<CustomerEntity> Customers { get; set; }
        public DbSet<CustomerOrderEntity> Orders { get; set; }
        public DbSet<OrderLineEntity> OrderLines { get; set; }
        public DbSet<InstallerReviewEntity> Reviews { get; set; }
        public DbSet<CarpetEntity> Carpets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //configure entity relationships 

            //Customer Order - Customer
            modelBuilder.Entity<CustomerOrderEntity>().HasOne(e => e.Customer)
                .WithMany(r => r.Orders)
                .HasForeignKey(t => t.CustomerId);

            //carpet properties - carpet
            modelBuilder.Entity<CarpetPropertyEntity>().HasOne(e => e.Carpet).WithMany().HasForeignKey(e => e.CarpetId);

            //carpet colour pallets  - carpet
            modelBuilder.Entity<CarpetColourPalletEntity>().HasOne(e => e.Carpet).WithMany()
                .HasForeignKey(e => e.CarpetId);

            //carpet size options - carpet
            modelBuilder.Entity<CarpetSizeOptionEntity>().HasOne(e => e.Carpet).WithMany()
                .HasForeignKey(e => e.CarpetId);

            //carpet images - carpet
            modelBuilder.Entity<CarpetImageEntity>().HasOne(e => e.Carpet).WithMany().HasForeignKey(e => e.CarpetId);

            //customer orders and reviews 
            modelBuilder.Entity<InstallerReviewEntity>().HasOne(e => e.Installer).WithMany()
                .HasForeignKey(e => e.InstallerId);

     
            // installer appointments 


        //    modelBuilder.Entity<CustomerOrderEntity>().HasOne(e => e.InstallerAppointment).WithOne();

            modelBuilder.Entity<InstallerAppointmentsEntity>().HasOne(e => e.Installer).WithMany()
                .HasForeignKey(e => e.InstallerId);

            //company location installer = rates 

            modelBuilder.Entity<CompanyLocationEntity>().HasMany(e => e.Rates).WithOne(e => e.CompanyLocation)
                .HasForeignKey(e => e.CompanyLocationId);

            // company - company locations 
            modelBuilder.Entity<CompanyLocationEntity>().HasOne(e => e.Company).WithMany(r => r.CompanyLocations)
                .HasForeignKey(e => e.CompanyId);




        }

    }
}
