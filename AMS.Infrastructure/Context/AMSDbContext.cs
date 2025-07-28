using AMS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.Infrastructure.Context
{
    public class AMSDbContext:DbContext
    {
        public AMSDbContext(DbContextOptions<AMSDbContext> options):base(options) { }
        
        public DbSet<Asset> assets { get; set; }
    }
}
