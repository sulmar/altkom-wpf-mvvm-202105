using Altkom.Shop.FakeServices;
using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Altkom.Shop.ViewModels
{
    public class ProductsViewModel : BaseViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<string> Colors { get; set; }

        public Product SelectedProduct { get; set; }

        public ICommand SaveCommand { get; private set; }

        private readonly IProductService productService;

        public ProductsViewModel()
            : this(new FakeProductService())
        {

        }

        public ProductsViewModel(IProductService productService)
        {
            this.productService = productService;

            Products = productService.Get();

            Colors = Products.Select(p => p.Color).Distinct().ToList();

            SaveCommand = new DelegateCommand(Save, CanSave);
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
    }
}
