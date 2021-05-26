using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Input;

namespace Altkom.Shop.ViewModels
{

    public class CustomersViewModel : BaseViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }

        public Customer SelectedCustomer
        {
            get => selectedCustomer; set
            {
                selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        private readonly ICustomerService customerService;
        private Customer selectedCustomer;

        public ICommand SendCommand { get; private set; }

        public CustomersViewModel(ICustomerService customerService)
        {
            this.customerService = customerService;

            Customers = this.customerService.Get();

            SendCommand = new DelegateCommand(Send);
        }

        public void Send()
        {
            Trace.WriteLine($"Send to {SelectedCustomer.FullName}");

            SelectedCustomer.FirstName = SelectedCustomer.FirstName + "!";
        }


    }
}
