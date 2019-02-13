using DeliveryService.Models;

namespace DeliveryService.PriceCalculation
{
    public abstract class PriceCalculate
    {
        protected PriceCalculate Next;

        public void SetNext(PriceCalculate next)
        {
            Next = next;
        }

        public abstract void Process(Product product, Customer customer, Order order);

        public void InvokeNext(Product product, Customer customer, Order order)
        {
            Next?.Process(product, customer, order);
        }
    }
}