using DeliveryService.Models;

namespace DeliveryService.Services
{
    public class ProductService
    {

        public Product GetById(int Id)
        {
            return new Product
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
            };
        }
    }
}