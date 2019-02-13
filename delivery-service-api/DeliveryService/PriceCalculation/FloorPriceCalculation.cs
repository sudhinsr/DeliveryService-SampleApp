using DeliveryService.Models;

namespace DeliveryService.PriceCalculation
{
    public class FloorPriceCalculation : PriceCalculate
    {
        public override void Process(Product product, Customer customer, Order order)
        {

            if (order.NoOfFloors <= 5)
            {
                order.Price += product.Price5Floor;
            }
            else
            {
                var additionalFloorPrice = (order.NoOfFloors - 6) * product.PriceEachFloor;
                order.Price = order.Price + product.Price5Floor + additionalFloorPrice;
            }

            InvokeNext(product, customer, order);
        }
    }
}