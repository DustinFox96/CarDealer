using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarDealer.Models;

namespace CarDealer.Data
{
    public class CarDealerDBContext : DbContext
    {
        public CarDealerDBContext (DbContextOptions<CarDealerDBContext> options)
            : base(options)
        {
        }

        public DbSet<Dealer> Dealer{ get; set; }

        public DbSet<Car> Car { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Dealer>(u =>
            {
                u.HasIndex(c => c.Code).IsUnique(true);
            });

            builder.Entity<Car>(u =>
            {
                u.HasIndex(v => v.Vin).IsUnique(true);
            });
        }
    }
}
