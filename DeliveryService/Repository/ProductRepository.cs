using DeliveryService.Models;
using DeliveryService.Repository.Interface;

namespace DeliveryService.Repository
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}