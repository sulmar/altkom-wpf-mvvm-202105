﻿using Altkom.Shop.FakeServices.Fakers;
using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using Bogus;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.Shop.FakeServices
{
    public class FakeProductService : FakeEntityService<Product>, IProductService
    {
        public FakeProductService()
            : this(new ProductFaker())
        {

        }

        public FakeProductService(Faker<Product> faker) : base(faker)
        {
        }

        public IEnumerable<Product> Get(string color)
        {
            return entities.Where(p => p.Color == color);
        }
    }
}
