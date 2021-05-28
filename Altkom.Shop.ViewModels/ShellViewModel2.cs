using Altkom.Shop.FakeServices;
using Altkom.Shop.FakeServices.Fakers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Altkom.Shop.ViewModels
{
    public class ShellViewModel2 : BaseViewModel
    {
        private BaseViewModel selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get => selectedViewModel; set
            {
                selectedViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowServicesViewCommand { get; set; }

        public ICommand ShowProductsViewCommand { get; set; }

        public ShellViewModel2()
        {
            ShowServicesViewCommand = new DelegateCommand(ShowServicesView);
            ShowProductsViewCommand = new DelegateCommand(ShowProductsView);
        }

        private void ShowProductsView()
        {
            SelectedViewModel = new ProductsViewModel(new FakeProductService(new ProductFaker()), new FakeProductCalculatorService());
        }

        private void ShowServicesView()
        {
            SelectedViewModel = new ServicesViewModel(new FakeServiceService(new ServiceFaker()));
        }
    }

}
