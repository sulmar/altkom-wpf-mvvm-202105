using Altkom.Shop.FakeServices.Fakers;
using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using Bogus;
using System.Linq;

namespace Altkom.Shop.FakeServices
{

    public class FakeCustomerServiceOptions
    {
        public int Quantity { get; set; }
    }

    public class FakeCustomerService : FakeEntityService<Customer>, ICustomerService
    {

        public FakeCustomerService(Faker<Customer> faker, FakeCustomerServiceOptions options) : base(faker)
        {
            
        }
    }
}
