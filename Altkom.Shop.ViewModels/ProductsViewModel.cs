using Altkom.Shop.FakeServices;
using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Altkom.Shop.ViewModels
{

    public class ProductsViewModel : BaseViewModel
    {
        public ICollection<Product> Products
        {
            get => products; set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        public IEnumerable<string> Colors
        {
            get => colors; set
            {
                colors = value;
                OnPropertyChanged();
            }
        }

        public decimal TotalAmount
        {
            get => totalAmount; set
            {
                totalAmount = value;
                OnPropertyChanged();
            }
        }



        public Product SelectedProduct
        {
            get => selectedProduct; set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }

        #region Commands

        public ICommand SaveCommand { get; private set; }
        public ICommand DiscountCommand { get; private set; }
        public ICommand CalculateCommand { get; private set; }
        public ICommand CancelCalculateCommand { get; private set; }
        public ICommand LoadCommand { get; private set; }

        #endregion

        private readonly IProductService productService;
        private readonly IProductCalculatorService productCalculator;
        private Product selectedProduct;
        private decimal totalAmount;
        private int counter;

        public ProductsViewModel(IProductService productService, IProductCalculatorService productCalculator)
        {
            this.productService = productService;
            this.productCalculator = productCalculator;

            SaveCommand = new DelegateCommand(Save, CanSave);
            DiscountCommand = new DelegateCommand<Product>(Discount);
            CalculateCommand = new DelegateCommand(Calculate);
            CancelCalculateCommand = new DelegateCommand(CancelCalculate);

            LoadCommand = new DelegateCommand(async () => await LoadAsync());
        }

        public async Task LoadAsync()
        {
            var products = await productService.GetAsync();

            Products = products.ToList();

            Colors = Products.Select(p => p.Color).Distinct().ToList();
        }

        public void Save()
        {
            if (SelectedProduct.Id == 0)
                productService.Add(SelectedProduct);
            else
                productService.Update(SelectedProduct);
        }

        public bool CanSave()
        {
            return true;
        }

        public void Discount(Product product)
        {
            product.UnitPrice -= product.UnitPrice * 0.1m;
        }

        public int Counter
        {
            get => counter; set
            {
                counter = value;
                OnPropertyChanged();
            }
        }

        CancellationTokenSource cancellationTokenSource;
        private ICollection<Product> products;
        private IEnumerable<string> colors;

        public async void Calculate()
        {
            IProgress<int> progress = new Progress<int>(counter => Counter = counter);

            cancellationTokenSource = new CancellationTokenSource(TimeSpan.FromSeconds(5));

            CancellationToken cancellationToken = cancellationTokenSource.Token;

            try
            {
                TotalAmount = await productCalculator.CalculateAsync(Products, cancellationToken, progress);
            }
            catch (OperationCanceledException e)
            {
                Counter = 0;
            }
        }

        public void CancelCalculate()
        {
            cancellationTokenSource.Cancel();
        }
    }
}
