using DeliverySystem.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DeliverySystem.Data.EF
{
    public class DeliveryContext : DbContext
    {
        public DeliveryContext(DbContextOptions<DeliveryContext> options)
       : base(options)
        { }

        public DbSet<Courier> Couriers { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Blog>()
              //  .Property(b => b.Url)
              //  .IsRequired();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=tcp:ilbontestserver.database.windows.net,1433;Initial Catalog=ilbonTestDb;Persist Security Info=False;User ID=ilbon;Password=1D41BBDA-031F;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;");
        }
    }
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DeliveryContext>
    {
        public DeliveryContext CreateDbContext(string[] args)
        {
           

            var builder = new DbContextOptionsBuilder<DeliveryContext>();

            var connectionString ="Server=tcp:ilbontestserver.database.windows.net,1433;Initial Catalog=ilbonTestDb;Persist Security Info=False;User ID=ilbon;Password=1D41BBDA-031F;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=60;";

            builder.UseSqlServer(connectionString);

            return new DeliveryContext(builder.Options);
        }
    }
}
