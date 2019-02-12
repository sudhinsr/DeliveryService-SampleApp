using System;
using System.Web.Http;
using DeliveryService.Models;
using DeliveryService.PriceCalculation;
using DeliveryService.Services;

namespace DeliveryService.Controllers
{
    [Route("order")]
    public class OrderController : ApiController
    {
        private readonly ProductService _productService;
        private readonly CustomerService _customerService;

        public OrderController(ProductService productService, CustomerService customerService)
        {
            _productService = productService;
            _customerService = customerService;
        }

        [HttpPost]
        public Order Get(Order order)
        {
            
            var product = _productService.GetById(order.ProductId);
            var customer = _customerService.GetById(order.CustomerId);

            return GetOrderEstimation(product, customer, order);
        }

        private PriceCalculate GetPriceCalculator(Order order)
        {
            var priceCalculate = new BasePriceCalculate();
            if (!order.IsWeekend)
            {
                priceCalculate.SetNext(new DistancePriceCalculate());
                if (order.HasFloor)
                {
                    priceCalculate.SetNext(new FloorPriceCalculation());
                }
            }

            return priceCalculate;
        }

        private Order GetOrderEstimation(Product product, Customer customer, Order order)
        {
            var priceCalculator = GetPriceCalculator(order);

            priceCalculator.Process(product, customer, order);

            return order;
        }

    }
}
