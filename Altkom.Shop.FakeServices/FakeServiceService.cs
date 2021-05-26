using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using Bogus;

namespace Altkom.Shop.FakeServices
{
    public class FakeServiceService : FakeEntityService<Service>, IServiceService
    {
        public FakeServiceService(Faker<Service> faker) : base(faker)
        {
        }
    }
}
