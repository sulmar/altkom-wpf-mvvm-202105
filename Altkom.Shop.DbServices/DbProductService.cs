using Altkom.Shop.IServices;
using System;
using Altkom.Shop.Models;
using System.Collections.Generic;
using Altkom.Shop.Models.SearchCriterias;
using System.Threading.Tasks;

namespace Altkom.Shop.DbServices
{

    // https://github.com/sulmar/altkom-wpf-201911/blob/ab1d43475e30a7684a7084da9a758c77c01f8ac9/20_MVVM/Altkom.Shop.DbServices/ShopContext.cs#L10
    public class DbProductService : IProductService
    {

        public void Add(Product entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get(string color)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get(ProductSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> Get()
        {
            throw new NotImplementedException();
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
