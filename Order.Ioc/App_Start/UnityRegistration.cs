using Order.Business.Implementation;
using Order.Business.Interface;
using Order.Repository.Implementation;
using Order.Repository.Infrastructure;
using Order.Repository.Interface;
using Microsoft.Practices.Unity;
using System.Web.Http;
using Business.Implementation;

namespace Order.Ioc.App_Start
{
    public class UnityRegistration
    {
        public static HttpConfiguration RegisterComponents()
        {
            var configuration = new HttpConfiguration();
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            container.RegisterType<ILoginBusiness, LoginBusiness>(new TransientLifetimeManager());
            container.RegisterType<ILoginRepository, LoginRepository>(new TransientLifetimeManager());
            container.RegisterType<IConnectionFactory, ConnectionFactory>(new TransientLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new TransientLifetimeManager());
            container.RegisterType<IOrderRepository, OrderRepository>(new TransientLifetimeManager());
            container.RegisterType<IProductBusiness, ProductBusiness>(new TransientLifetimeManager());
            container.RegisterType<IOrderBusiness, OrderBusiness>(new TransientLifetimeManager());

            configuration.DependencyResolver = new UnityConfig(container);
            return configuration;
        }
    }
}