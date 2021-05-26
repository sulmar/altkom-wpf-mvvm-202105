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
            containerBuilder.RegisterType<FakeCustomerService>().As<ICustomerService>();
            containerBuilder.RegisterType<CustomerFaker>().As<Faker<Customer>>();
            containerBuilder.RegisterType<CustomersViewModel>();
            containerBuilder.Register(p => new FakeCustomerServiceOptions { Quantity = 5 });

            container = containerBuilder.Build();
        }

        // public CustomersViewModel CustomersViewModel => new CustomersViewModel(new FakeCustomerService(new CustomerFaker()));

        public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();

        public ProductsViewModel ProductsViewModel => new ProductsViewModel(new FakeProductService(new ProductFaker()));

        public ShellViewModel ShellViewModel => new ShellViewModel();
    }
}
