using DeliveryService.Controllers;
using DeliveryService.Models;
using DeliveryService.Repository.Interface;
using Moq;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace DeliveryService.Tests
{
    public class TestOrderController
    {
        private readonly Mock<ICustomerRepository> _customerRepositoryMock = new Mock<ICustomerRepository>();
        private readonly Mock<IOrderRepository> _orderRepositoryMock = new Mock<IOrderRepository>();
        private readonly Mock<IProductRepository> _productRepositoryMock = new Mock<IProductRepository>();

        private readonly OrderController _orderController;

        public TestOrderController()
        {
            _orderController = new OrderController(_productRepositoryMock.Object, _customerRepositoryMock.Object, _orderRepositoryMock.Object);
        }

        [Test]
        public async Task Order_Under_10Km_0F()
        {
            var order = new Order
            {
                CustomerId = 1,
                ProductId = 1,
                Distance = 5,
                NoOfFloors = 0,
                DeliveryDate = new DateTime(2019, 1, 1)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = false,
                        IsNewCustomer = false
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(1098.9M, order.Price);
        }

        [Test]
        public async Task New_Customer_0KM_0F()
        {
            var order = new Order
            {
                CustomerId = 1,
                ProductId = 1,
                DeliveryDate = new DateTime(2019, 1, 1)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = false,
                        IsNewCustomer = true
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(849.5M, order.Price);
        }

        [Test]
        public async Task Golden_Customer_0KM_0F()
        {
            var order = new Order
            {
                CustomerId = 1,
                ProductId = 1,
                DeliveryDate = new DateTime(2019, 1, 1)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = true,
                        IsNewCustomer = false
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(899.1M, order.Price);
        }

        [Test]
        public async Task Coupon_Order_0KM_0F()
        {
            var order = new Order
            {
                Coupon = "OK",
                CustomerId = 1,
                ProductId = 1,
                DeliveryDate = new DateTime(2019, 1, 1)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = false,
                        IsNewCustomer = false
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(799.2M, order.Price);
        }

        [Test]
        public async Task Base_Order_0KM_0F()
        {
            var order = new Order
            {
                CustomerId = 1,
                ProductId = 1,
                DeliveryDate = new DateTime(2019, 1, 1)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = false,
                        IsNewCustomer = false
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(999M, order.Price);
        }

        [Test]
        public async Task Weekend_Order_0KM_0F()
        {
            var order = new Order
            {
                CustomerId = 1,
                ProductId = 1,
                DeliveryDate = new DateTime(2019, 1, 5)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = false,
                        IsNewCustomer = false
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(1498.5M, order.Price);
        }

        [Test]
        public async Task Base_Order_50KM_0F()
        {
            var order = new Order
            {
                CustomerId = 1,
                ProductId = 1,
                Distance = 50,
                DeliveryDate = new DateTime(2019, 1, 1)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = false,
                        IsNewCustomer = false
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(1248.75M, order.Price);
        }

        [Test]
        public async Task Base_Order_51KM_0F()
        {
            var order = new Order
            {
                CustomerId = 1,
                ProductId = 1,
                Distance = 51,
                DeliveryDate = new DateTime(2019, 1, 1)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = false,
                        IsNewCustomer = false
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(1249M, order.Price);
        }

        [Test]
        public async Task Base_Order_0KM_5F()
        {
            var order = new Order
            {
                CustomerId = 1,
                ProductId = 1,
                NoOfFloors = 5,
                DeliveryDate = new DateTime(2019, 1, 1)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = false,
                        IsNewCustomer = false
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(1048.95M, order.Price);
        }

        [Test]
        public async Task Base_Order_0KM_7F()
        {
            var order = new Order
            {
                CustomerId = 1,
                ProductId = 1,
                NoOfFloors = 7,
                DeliveryDate = new DateTime(2019, 1, 1)
            };

            _customerRepositoryMock.Setup(_ => _.GetAsync(order.CustomerId))
                .Returns(Task.FromResult(
                    new Customer
                    {
                        CustomerId = 1,
                        CustomerName = "Abc",
                        IsGoldenCustomer = false,
                        IsNewCustomer = false
                    }));


            _productRepositoryMock.Setup(_ => _.GetAsync(order.ProductId))
                .Returns(Task.FromResult(
                    new Product()
                    {
                        ProductId = 1,
                        ProductName = "Duster",
                        BasePrice = 999M,
                        CouponPrice = 799.2M,
                        GoldenCustomerPrice = 899.1M,
                        WeekendPrice = 1498.5M,
                        NewCustomerPrice = 849.5M,
                        Price10Km = 99.9M,
                        Price50Km = 249.75M,
                        PriceEachKm = .25M,
                        Price5Floor = 49.95M,
                        PriceEachFloor = 4M
                    }));

            var result = await _orderController.GetFeeEstimation(order);

            Assert.NotNull(result);
            Assert.NotZero(order.Price);
            Assert.AreEqual(1052.95M, order.Price);
        }
    }
}
