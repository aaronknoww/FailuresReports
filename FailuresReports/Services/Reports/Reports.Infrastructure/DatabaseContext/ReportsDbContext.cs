using Microsoft.EntityFrameworkCore;
using Reports.Core.Entities;

namespace Reports.Infrastructure.DatabaseContext
{
    public class ReportsDbContext : DbContext
    {
        public ReportsDbContext(DbContextOptions<ReportsDbContext> options) : base(options)
        {
        }

        // Define DbSets for views
        public DbSet<FailureRegistrationSYSFTEntity> SysftView { get; set; }
        public DbSet<FailureRegistrationSYSVFEntity> SysvfView { get; set; }
        public DbSet<PendingValidationEntity> PendingValidationView { get; set; }
        public DbSet<ToMrbEntity> ToMrbView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Map views explicitly
            modelBuilder.Entity<FailureRegistrationSYSFTEntity>()
                .ToView("FailureRegistrationSYSFTView")
                .HasKey(e => e.SerialNumber); // Define a key (views must have a primary key-like column)

            modelBuilder.Entity<FailureRegistrationSYSVFEntity>()
                .ToView("FailureRegistrationSYSVFView")
                .HasKey(e => e.SerialNumber);

            modelBuilder.Entity<PendingValidationEntity>()
                .ToView("PendingValidationView")
                .HasKey(e => e.SerialNumber);

            modelBuilder.Entity<ToMrbEntity>()
                .ToView("ToMrbView")
                .HasKey(e => e.SerialNumber);
        }
    }
}

