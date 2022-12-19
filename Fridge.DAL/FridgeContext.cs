using FridgeApi.DAL.Configurations;
using FridgeApi.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FridgeApi.DAL
{
    public class FridgeContext : DbContext
    {
        public DbSet<FridgeModel> FridgeModels { get; set; }

        public DbSet<Fridge> Fridges { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<FridgeProduct> FridgeProducts { get; set; }

        public DbSet<Account>  Accounts { get; set; }

        public FridgeContext(DbContextOptions<FridgeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FridgeModel>(entity => {
                entity.ToTable("Fridge_Model");
            });
            modelBuilder.Entity<Fridge>(entity => {
                entity.ToTable("Fridge");
            });
            modelBuilder.Entity<Product>(entity => {
                entity.ToTable("Products");
            });
            modelBuilder.Entity<FridgeProduct>(entity => {
                entity.ToTable("Fridge_Products");
            });
            modelBuilder.Entity<Account>(entity => {
                entity.ToTable("Accounts");
            });

            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new FridgeModelConfiguration());
        }
    }
}
