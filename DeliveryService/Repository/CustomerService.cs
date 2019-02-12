using DeliveryService.Models;

namespace DeliveryService.Services
{
    public class CustomerService
    {
        public CustomerService()
        {
        }

        public Customer GetById(int Id)
        {
            return new Customer
            {
                CustomerId = 1,
                CustomerName = "Abc",
                IsGoldenCustomer = true,
                IsNewCustomer = true
            };
        }
    }
}