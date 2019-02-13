using System.Data;
using DeliveryService.Models;
using DeliveryService.PriceCalculation;
using DeliveryService.Repository.Interface;
using System.Threading.Tasks;
using System.Web.Http;

namespace DeliveryService.Controllers
{
    [RoutePrefix("order")]
    public class OrderController : ApiController
    {
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;

        public OrderController(IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        [Route("fee-estimation")]
        [HttpPost]
        public async Task<Order> Get(Order order)
        {
            var product = await _productRepository.GetAsync(order.ProductId);
            var customer = await _customerRepository.GetAsync(order.CustomerId);

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
