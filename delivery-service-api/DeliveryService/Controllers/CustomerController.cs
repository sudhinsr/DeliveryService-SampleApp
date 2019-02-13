using DeliveryService.Models;
using DeliveryService.Repository.Interface;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Http;

namespace DeliveryService.Controllers
{
    [RoutePrefix("customer")]
    public class CustomerController : ApiController
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [Route]
        [HttpGet]
        public async Task<Customer[]> Get() => await _customerRepository.Query().ToArrayAsync();

        [Route]
        [HttpPost]
        public async Task<Customer> Add(Customer customer)
        {
            await _customerRepository.InsertAsync(customer);
            return customer;
        }

        [Route]
        [HttpPut]
        public async Task<Customer> Update(Customer customer)
        {
            await _customerRepository.UpdateAsync(customer);
            return customer;
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<Customer> Get(int id) => await _customerRepository.GetAsync(id);
    }
}
