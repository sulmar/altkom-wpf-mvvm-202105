using Altkom.Shop.FakeServices;
using Altkom.Shop.FakeServices.Fakers;
using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using Altkom.Shop.ViewModels;
using Autofac;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Shop.WpfClient
{
    public class ViewModelLocator
    {

        // dotnet add package AutoFac

        private readonly IContainer container;

        public ViewModelLocator()
        {
            ContainerBuilder containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<FakeCustomerService>().As<ICustomerService>().SingleInstance();
            containerBuilder.RegisterType<CustomerFaker>().As<Faker<Customer>>();

            containerBuilder.RegisterType<PolishAddressFaker>().As<Faker<Address>>();
            containerBuilder.RegisterType<ForeignAddressFaker>().As<Faker<Address>>();

            // containerBuilder.RegisterType<CustomersViewModel>();

            containerBuilder.Register(p => new FakeCustomerServiceOptions { Quantity = 5 });

            containerBuilder.RegisterType<FakeProductService>().As<IProductService>();
            containerBuilder.RegisterType<ProductFaker>().As<Faker<Product>>();
            // containerBuilder.RegisterType<ProductsViewModel>();

            containerBuilder.RegisterType<FakeServiceService>().As<IServiceService>();
            containerBuilder.RegisterType<ServiceFaker>().As<Faker<Service>>();

            // containerBuilder.RegisterType<ShellViewModel>();

            // Automatyzacja rejestracji
            containerBuilder.RegisterAssemblyTypes(typeof(BaseViewModel).Assembly) 
                .Where(t => t.IsSubclassOf(typeof(BaseViewModel))); // Zarejestruj wszystkie klasy, które dziedziczą po BaseViewModel

            containerBuilder.RegisterType<WpfMessageBoxService>().As<IMesageBoxService>();
                


            container = containerBuilder.Build();
        }

        // public CustomersViewModel CustomersViewModel => new CustomersViewModel(new FakeCustomerService(new CustomerFaker()));
        // public ProductsViewModel ProductsViewModel => new ProductsViewModel(new FakeProductService(new ProductFaker()));

        public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();
        public ProductsViewModel ProductsViewModel => container.Resolve<ProductsViewModel>();
        public ServicesViewModel ServicesViewModel => container.Resolve<ServicesViewModel>();
        public ShellViewModel ShellViewModel => container.Resolve<ShellViewModel>();

        


    }
}
