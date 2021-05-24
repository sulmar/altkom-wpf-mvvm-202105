using Altkom.Shop.FakeServices.Fakers;
using Altkom.Shop.IServices;
using Altkom.Shop.Models;
using Bogus;
using System;
using System.Collections.Generic;

namespace Altkom.Shop.FakeServices
{
    public class FakeCustomerService : ICustomerService
    {
        private ICollection<Customer> customers;

        public FakeCustomerService()
            : this(new CustomerFaker())
        {

        }

        // snippet: ctor + 2 x TAB
        public FakeCustomerService(Faker<Customer> faker)
        {
            customers = faker.Generate(100);
        }

        public void Add(Customer customer)
        {
            customers.Add(customer);
        }

        public IEnumerable<Customer> Get()
        {
            return customers;
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
