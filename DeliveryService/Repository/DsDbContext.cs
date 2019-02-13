using DeliveryService.Models;
using System.Data.Entity;

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
            modelBuilder.Entity<Product>().Map(m => m.ToTable("Product"))   
                .HasKey(t => t.ProductId);

            modelBuilder.Entity<Customer>().Map(m => m.ToTable("Customer"))
                .HasKey(t => t.CustomerId);

            modelBuilder.Entity<Order>().Map(m => m.ToTable("Order"))
                .HasKey(t => t.OrderId);
        }
    }
}