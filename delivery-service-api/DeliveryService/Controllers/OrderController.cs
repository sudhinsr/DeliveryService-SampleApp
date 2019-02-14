using DeliveryService.Models;
using DeliveryService.PriceCalculation;
using DeliveryService.Repository.Interface;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace DeliveryService.Controllers
{
    [RoutePrefix("order")]
    public class OrderController : ApiController
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderController(IProductRepository productRepository,
            ICustomerRepository customerRepository,
            IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
            _orderRepository = orderRepository;
        }

        [HttpPost]
        [Route("price-estimation")]
        public async Task<Order> GetFeeEstimation(Order order)
        {
            var product = await _productRepository.GetAsync(order.ProductId);
            var customer = await _customerRepository.GetAsync(order.CustomerId);

            return GetOrderEstimation(product, customer, order);
        }

        [Route]
        [HttpPost]
        public async Task<Order> Order(Order order)
        {
            var product = await _productRepository.GetAsync(order.ProductId);
            var customer = await _customerRepository.GetAsync(order.CustomerId);

            var estimation = GetOrderEstimation(product, customer, order);

            if(estimation.Price != order.Price)
                throw new InvalidOperationException("Price changed");

            await _orderRepository.InsertAsync(estimation);

            return estimation;
        }

        private PriceCalculate GetPriceCalculator(Order order)
        {
            var priceCalculate = new BasePriceCalculate();
            if (!order.IsWeekend)
            {
                if (order.HasDistance)
                {
                    priceCalculate.SetNext(new DistancePriceCalculate());
                }

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
