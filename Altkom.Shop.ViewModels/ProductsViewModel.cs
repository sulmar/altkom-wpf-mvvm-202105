using Altkom.Shop.FakeServices;
using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Altkom.Shop.ViewModels
{

    public class ProductsViewModel : BaseViewModel
    {
        public ICollection<Product> Products { get; set; }

        public IEnumerable<string> Colors { get; set; }

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

            Products = productService.Get().ToList();

            Colors = Products.Select(p => p.Color).Distinct().ToList();

            SaveCommand = new DelegateCommand(Save, CanSave);
            DiscountCommand = new DelegateCommand<Product>(Discount);
            CalculateCommand = new DelegateCommand(Calculate);

           
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


        public async void Calculate()
        {
            IProgress<int> progress = new Progress<int>(counter => Counter = counter);

            TotalAmount = await productCalculator.CalculateAsync(Products, progress);
        }
    }
}
