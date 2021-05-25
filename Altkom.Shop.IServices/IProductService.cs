using Altkom.Shop.Models;
using System.Collections.Generic;

namespace Altkom.Shop.IServices
{
    public interface IProductService : IEntityService<Product>
    {
        IEnumerable<Product> Get(string color);
    }
}
