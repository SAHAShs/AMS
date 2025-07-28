using AMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Infrastructure.Context
{
    public class AMSDbContext : DbContext
    {
        public AMSDbContext(DbContextOptions<AMSDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asset>()
                .HasOne(a => a.AllocatedEmployee)
                .WithMany(e => e.AssignedAssets)
                .HasForeignKey(a => a.AllocatedTo)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Asset>()
                .Property(a => a.Status)
                .HasConversion<string>();

            modelBuilder.Entity<Asset>()
                .HasOne(a => a.Category)
                .WithMany(c => c.Assets)
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        }
        public DbSet<Asset> assets { get; set; }
        public DbSet<Employee> employees { get; set;}
    }
}
