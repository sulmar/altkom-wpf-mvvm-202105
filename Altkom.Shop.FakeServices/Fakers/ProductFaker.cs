using Altkom.Shop.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Shop.FakeServices.Fakers
{
    class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            string[] colors = new string[] { "red", "blue", "green" };

            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.Color, f => f.PickRandom(colors));
        }
    }
}
