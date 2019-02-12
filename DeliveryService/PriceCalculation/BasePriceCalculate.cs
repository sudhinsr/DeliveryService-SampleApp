using DeliveryService.Models;

namespace DeliveryService.PriceCalculation
{
    public class BasePriceCalculate : PriceCalculate
    {
        public override void Process(Product product, Customer customer, Order order)
        {
            if (order.IsWeekend)
            {
                order.Price = product.WeekendPrice;
            }
            else if (order.HasCoupon)
            {
                //do the coupon validation here
                order.Price = product.CouponPrice;
            }
            else if (customer.IsNewCustomer)
            {
                order.Price = product.NewCustomerPrice;
            }
            else if (customer.IsGoldenCustomer)
            {
                order.Price = product.GoldenCustomerPrice;
            }
            else
            {
                order.Price = product.BasePrice;
            }

            InvokeNext(product, customer, order);
        }
    }
}