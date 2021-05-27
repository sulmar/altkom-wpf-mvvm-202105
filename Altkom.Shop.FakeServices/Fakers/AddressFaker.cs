using Altkom.Shop.Models;
using Bogus;

namespace Altkom.Shop.FakeServices.Fakers
{
    public class PolishAddressFaker : Faker<Address>
    {
        public PolishAddressFaker()
        {
            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.Country, f => "Poland");
            RuleFor(p => p.Street, f => "Dworcowa");
            RuleFor(p => p.ZipCode, f => f.Address.ZipCode());
        }

        public override string ToString() => "Polish";
    }

    public class ForeignAddressFaker : Faker<Address>
    {
        public ForeignAddressFaker()
        {
            RuleFor(p => p.City, f => f.Address.City());
            RuleFor(p => p.Country, f => f.Address.Country());
            RuleFor(p => p.Street, f => f.Address.StreetAddress());
            RuleFor(p => p.ZipCode, f => f.Address.ZipCode());
        }

        public override string ToString() => "Foreign";
    }
}
