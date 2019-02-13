using DeliveryService.Models;
using DeliveryService.Repository.Interface;

namespace DeliveryService.Repository
{
    public class CustomerRepository : GenericRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(DsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}