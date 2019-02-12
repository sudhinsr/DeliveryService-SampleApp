using DeliveryService.Models;

namespace DeliveryService.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DeliveryService.Repository.DsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DeliveryService.Repository.DsDbContext context)
        {
            context.Set<Product>().AddOrUpdate(new Product
            {
                ProductId = 1,
                ProductName = "Duster",
                BasePrice = 999M,
                CouponPrice = 799.2M,
                GoldenCustomerPrice = 899.1M,
                WeekendPrice = 1498.5M,
                NewCustomerPrice = 849.5M,
                Price10Km = 99.9M,
                Price50Km = 249.75M,
                PriceEachKm = .25M,
                Price5Floor = 49.95M,
                PriceEachFloor = 4M
            });

            context.Set<Customer>().AddOrUpdate(new Customer
            {
                CustomerId = 1,
                CustomerName = "Abc",
                IsGoldenCustomer = true,
                IsNewCustomer = true
            });
        }
    }
}
