using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using Bogus;
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
        

        public IEnumerable<Faker<Address>> AddressFakers { get; private set; }

        private Faker<Address> selectedAddressFaker;
        public Faker<Address> SelectedAddressFaker 
        { 
            get => selectedAddressFaker; 
            set 
            {
                selectedAddressFaker = value;
                GenerateAddresses();
            }
        }

        private void GenerateAddresses()
        {
            SelectedCustomer.ShipAddress = SelectedAddressFaker.Generate();
            SelectedCustomer.InvoiceAddress = SelectedAddressFaker.Generate();
        }

        public ICommand SendCommand { get; private set; }

        public CustomersViewModel(ICustomerService customerService, IEnumerable<Faker<Address>> addressFakers)
        {
            this.customerService = customerService;
            this.AddressFakers = addressFakers;

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
