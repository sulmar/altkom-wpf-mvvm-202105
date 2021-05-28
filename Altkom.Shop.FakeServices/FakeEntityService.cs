using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Altkom.Shop.FakeServices
{
    public class FakeEntityService<TEntity> : IEntityService<TEntity>
        where TEntity : BaseEntity
    {
        protected ICollection<TEntity> entities;

        readonly TimeSpan interval = TimeSpan.FromSeconds(5);

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
            // Thread.Sleep(interval);

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
