using Altkom.Shop.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Shop.FakeServices.Fakers
{
    public class ProductFaker : Faker<Product>
    {
        public ProductFaker()
        {
            // string[] colors = new string[] { "red", "blue", "green" };

            RuleFor(p => p.Id, f => f.IndexFaker);
            // RuleFor(p => p.Color, f => f.PickRandom(colors));
            RuleFor(p => p.Color, f => f.Commerce.Color());
            RuleFor(p => p.Name, f => f.Commerce.ProductName());
            RuleFor(p => p.UnitPrice, f => decimal.Parse(f.Commerce.Price()));
            RuleFor(p => p.Weight, f => f.Random.Float(1, 1000));
        }
    }
}
