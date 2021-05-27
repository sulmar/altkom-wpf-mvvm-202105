using Altkom.Shop.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Shop.FakeServices.Fakers
{
    public class ServiceFaker : Faker<Service>
    {
        public ServiceFaker()
        {
            StrictMode(true);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Name, f => f.Hacker.IngVerb());
            RuleFor(p => p.Duration, f => TimeSpan.FromMinutes(f.Random.Double(1, 120)));
            RuleFor(p => p.UnitPrice, f => Math.Round(f.Random.Decimal(50, 200), 0));
            Ignore(p => p.IsDirty);
        }
    }
}
