using System;
using System.Reflection;
using MiniCarsales.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace MiniCarsales.Infrastructure.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {

        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vehicle>()
                .HasDiscriminator(b => b.VehicleType);
                  base.OnModelCreating(builder);
        }
    }
}