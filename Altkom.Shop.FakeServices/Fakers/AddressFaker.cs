using Altkom.Shop.Models;
using Bogus;

namespace Altkom.Shop.FakeServices.Fakers
{
    public class AddressFaker : Faker<Address>
    {
        public AddressFaker()
        {
            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.Country, f => f.Address.Country());
            RuleFor(p => p.Street, f => f.Address.StreetAddress());
            RuleFor(p => p.ZipCode, f => f.Address.ZipCode());
        }
    }
}
