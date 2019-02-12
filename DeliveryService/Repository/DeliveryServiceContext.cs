using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using DeliveryService.Models;

namespace DeliveryService.Repository
{
    public class DsDbContext : DbContext
    {
        public DsDbContext() : base("name=DsContext")
        {
        }

        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Order> Order { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Map(m => m.ToTable("Product"));
            modelBuilder.Entity<Customer>().Map(m => m.ToTable("Customer"));
            modelBuilder.Entity<Order>().Map(m => m.ToTable("Order"));
        }
    }
}