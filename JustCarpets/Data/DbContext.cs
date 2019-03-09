using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustCarpets.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace JustCarpets.Data
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        
            public DbContext(DbContextOptions<DbContext> options)
                : base(options)
            {
            }

            public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<CompanyLocationEntity> CompanyLocations { get; set; }
        public DbSet<InstallerRatesEntity> InstallerRates { get; set; }
        public DbSet<InstallerAppointmentsEntity> InstallerAppointments { get; set; }
        public DbSet<CompanyLocation> Customers { get; set; }
        public DbSet<CustomerOrderEntity> Orders { get; set; }
        public DbSet<OrderLineEntity> OrderLines { get; set; }
        public DbSet<InstallerReviewEntity> Reviews { get; set; }
    }
}
