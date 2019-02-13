using System.Collections.Generic;

namespace DeliveryService.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal BasePrice { get; set; }
        public decimal NewCustomerPrice { get; set; }
        public decimal GoldenCustomerPrice { get; set; }
        public decimal CouponPrice { get; set; }
        public decimal WeekendPrice { get; set; }
        public decimal Price10Km { get; set; }
        public decimal Price50Km { get; set; }
        public decimal PriceEachKm { get; set; }
        public decimal Price5Floor { get; set; }
        public decimal PriceEachFloor { get; set; }

        public virtual ICollection<Order> Order { get; set; }
    }
}