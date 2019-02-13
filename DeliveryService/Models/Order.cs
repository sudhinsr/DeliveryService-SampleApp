using System;

namespace DeliveryService.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string Coupon { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public int Distance { get; set; }
        public int NoOfFloors { get; set; }
        public DateTime DeliveryDate { get; set; }
        public decimal Price { get; set; }

        public bool HasFloor => NoOfFloors > 0;
        public bool HasCoupon => !string.IsNullOrEmpty(Coupon);
        public bool IsWeekend =>
            DeliveryDate.DayOfWeek == DayOfWeek.Saturday || DeliveryDate.DayOfWeek == DayOfWeek.Sunday;

        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}