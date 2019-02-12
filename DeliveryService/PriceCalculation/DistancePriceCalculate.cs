using DeliveryService.Models;

namespace DeliveryService.PriceCalculation
{
    public class DistancePriceCalculate : PriceCalculate
    {
        public override void Process(Product product, Customer customer, Order order)
        {
            if (order.Distance <= 10)
            {
                order.Price += product.Price10Km;
            }
            else if (order.Distance <= 50)
            {
                order.Price += product.Price50Km;
            }
            else
            {
                var additionalPrice = (order.Distance - 50) * product.PriceEachKm;
                order.Price = order.Price + product.Price50Km + additionalPrice;
            }

            InvokeNext(product, customer, order);
        }
    }
}