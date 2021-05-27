using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Altkom.Shop.FakeServices
{
    public class FakeEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        protected ICollection<TEntity> entities;

        public FakeEntityService(Faker<TEntity> faker)
        {
            entities = faker.Generate(10);


            
        }

        public void Add(TEntity entity)
        {
            entities.Add(entity);
        }

        public IEnumerable<TEntity> Get()
        {
            return entities;
        }

        public TEntity Get(int id)
        {
            return entities.SingleOrDefault(p => p.Id == id);
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
