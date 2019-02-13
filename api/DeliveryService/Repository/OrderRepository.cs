using DeliveryService.Models;
using DeliveryService.Repository.Interface;

namespace DeliveryService.Repository
{
    public class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(DsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}