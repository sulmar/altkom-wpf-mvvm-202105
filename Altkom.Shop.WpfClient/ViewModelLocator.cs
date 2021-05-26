using Altkom.Shop.FakeServices;
using Altkom.Shop.FakeServices.Fakers;
using Altkom.Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Shop.WpfClient
{
    public class ViewModelLocator
    {

        public ViewModelLocator()
        {

        }

        public CustomersViewModel CustomersViewModel => new CustomersViewModel(new FakeCustomerService(new CustomerFaker()));
        public ProductsViewModel ProductsViewModel => new ProductsViewModel(new FakeProductService(new ProductFaker()));

        public ShellViewModel ShellViewModel => new ShellViewModel();
    }
}
