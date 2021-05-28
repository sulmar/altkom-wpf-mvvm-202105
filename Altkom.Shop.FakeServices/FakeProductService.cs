using Altkom.Shop.IServices;
using Altkom.Shop.Models;
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

        public Task<IEnumerable<Product>> GetAsync()
        {
            return Task.Run(() => Get());
        }
    }
}
