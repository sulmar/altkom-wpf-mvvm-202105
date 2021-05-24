using Altkom.Shop.FakeServices;
using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using System;
using System.Collections.Generic;

namespace Altkom.Shop.ViewModels
{

    public class CustomersViewModel : BaseViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public Customer SelectedCustomer { get; set; }

        private readonly ICustomerService customerService;

        public CustomersViewModel()
            : this(new FakeCustomerService())
        {
        }

        public CustomersViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;

            Customers = this.customerService.Get();
        }

    }
}
