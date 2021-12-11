using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TP.Core.Models;

namespace TP.Infrastructure
{
    public class Context : DbContext
    {
        protected string conStr;

        public Context() : base()
        {
            conStr = "Server=localhost;Database=testdb;Trusted_Connection=True;";
        }

        public Context(DbContextOptions<Context> options) : base(options) { }


        public DbSet<Company> Companies { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (conStr != null)
            {
                builder.UseSqlServer(conStr);
            }
            builder.UseLazyLoadingProxies(true);
            base.OnConfiguring(builder);
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Company>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Driver>().HasQueryFilter(x => !x.IsDeleted);
            builder.Entity<Vehicle>().HasQueryFilter(x => !x.IsDeleted);
        }


        public override async Task<int> SaveChangesAsync(CancellationToken token = default)
        {
            try
            {
                foreach (var entry in ChangeTracker.Entries().Where(
                    x => x.State == EntityState.Deleted && x.Entity is BaseClass))
                {
                    entry.State = EntityState.Modified;
                    entry.CurrentValues["IsDeleted"] = true;
                }
                return await base.SaveChangesAsync(token);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
