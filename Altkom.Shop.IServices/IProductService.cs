using Altkom.Shop.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Altkom.Shop.IServices
{
    public interface IProductService : IEntityService<Product>
    {
        IEnumerable<Product> Get(string color);
        Task<IEnumerable<Product>> GetAsync();

    }   
}
