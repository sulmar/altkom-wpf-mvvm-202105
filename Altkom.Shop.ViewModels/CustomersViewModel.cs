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
            get => selectedCustomer; 
            set
            {
                if (selectedCustomer != null && (selectedCustomer.IsDirty || selectedCustomer.InvoiceAddress.IsDirty || selectedCustomer.ShipAddress.IsDirty))
                {
                    bool result = mesageBoxService.ShowDialog("Customer", "Would you save changes?");

                    if (result)
                    {
                        SelectedCustomer.EndEdit();

                        customerService.Update(SelectedCustomer);

                        SelectedCustomer.ResetDirty();

                    }
                    else
                    {
                        SelectedCustomer.CancelEdit();

                        SelectedCustomer.ResetDirty();
                    }
                }

                selectedCustomer = value;


                OnPropertyChanged();

                SelectedCustomer.BeginEdit();
            }
        }

        private readonly ICustomerService customerService;
        private readonly IMesageBoxService mesageBoxService;
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

        public CustomersViewModel(ICustomerService customerService, IEnumerable<Faker<Address>> addressFakers, IMesageBoxService mesageBoxService)
        {
            this.customerService = customerService;
            this.AddressFakers = addressFakers;
            this.mesageBoxService = mesageBoxService;
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
