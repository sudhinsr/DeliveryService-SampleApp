using Autofac;
using Autofac.Integration.WebApi;
using DeliveryService.Repository;
using DeliveryService.Repository.Interface;
using System.Reflection;
using System.Web.Http;
using Swashbuckle.Application;

namespace DeliveryService
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var builder = new ContainerBuilder();

            // Get your HttpConfiguration.
            var config = GlobalConfiguration.Configuration;

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DsDbContext>().InstancePerRequest();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>();
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<ProductRepository>().As<IProductRepository>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

        }
    }
}
