using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using Altkom.Shop.Models.SearchCriterias;
using Bogus;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Altkom.Shop.FakeServices
{
    public class FakeProductService : FakeEntityService<Product>, IProductService
    {
        

        public FakeProductService(Faker<Product> faker) : base(faker)
        {
        }

        public IEnumerable<Product> Get(string color)
        {
            

            return entities.Where(p => p.Color == color);
        }

        public IEnumerable<Product> Get(ProductSearchCriteria searchCriteria)
        {
            IQueryable<Product> query = entities.AsQueryable();

            if (searchCriteria.UnitPriceFrom.HasValue)
            {
                query = query.Where(p => p.UnitPrice >= searchCriteria.UnitPriceFrom);
            }

            if (searchCriteria.UnitPriceTo.HasValue)
            {
                query = query.Where(p => p.UnitPrice <= searchCriteria.UnitPriceTo);
            }

            if (searchCriteria.WeightFrom.HasValue)
            {
                query = query.Where(p => p.Weight >= searchCriteria.WeightFrom);
            }

            if (searchCriteria.WeightTo.HasValue)
            {
                query = query.Where(p => p.Weight <= searchCriteria.WeightTo);
            }

            if (!string.IsNullOrEmpty(searchCriteria.Color))
            {
                query = query.Where(p => p.Color == searchCriteria.Color);
            }

            var products = query.ToList();

            return products;

            // entities.Where(p=>p.UnitPrice >= searchCriteria.UnitPriceFrom)
        }

        public Task<IEnumerable<Product>> GetAsync()
        {
            return Task.Run(() => Get());
        }
    }
}
