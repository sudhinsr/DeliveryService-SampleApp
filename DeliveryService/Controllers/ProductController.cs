using DeliveryService.Models;
using DeliveryService.Repository.Interface;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace DeliveryService.Controllers
{
    [RoutePrefix("product")]
    public class ProductController : ApiController
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [Route]
        [HttpGet]
        public async Task<Product[]> Get() => await _productRepository.Query().ToArrayAsync();

        [Route("{id}")]
        [HttpGet]
        public async Task<Product> Get(int id) => await _productRepository.GetAsync(id);

        [Route]
        [HttpPost]
        public async Task<Product> Add(Product product)
        {
            await _productRepository.InsertAsync(product);
            return product;
        }

        [Route]
        [HttpPut]
        public async Task<Product> Update(Product product)
        {
            await _productRepository.UpdateAsync(product);
            return product;
        }
    }
}
