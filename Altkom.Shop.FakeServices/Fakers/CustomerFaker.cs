using Altkom.Shop.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Altkom.Shop.FakeServices.Fakers
{

    // dotnet add package Bogus
    public class CustomerFaker : Faker<Customer>
    {
        public CustomerFaker(Faker<Address> addressFaker)
        {
            StrictMode(true);
            UseSeed(1);
            RuleFor(p => p.Id, f => f.IndexFaker);
            RuleFor(p => p.FirstName, f => f.Person.FirstName);
            RuleFor(p => p.LastName, f => f.Person.LastName);
            RuleFor(p => p.Email, (f, customer) => $"{customer.FirstName}.{customer.LastName}@domain.com"); // firstname.lastname@domain.com
            RuleFor(p => p.CustomerType, f => f.PickRandom<CustomerType>());
            RuleFor(p => p.Avatar, f => f.Person.Avatar);
            RuleFor(p => p.DateOfBirth, f => f.Person.DateOfBirth);
            RuleFor(p => p.CreditAmount, f => f.Random.Decimal(0, 1000));
            RuleFor(p => p.IsRemoved, f => f.Random.Bool(0.2f));

            //RuleFor(p => p.InvoiceAddress, f => addressFaker.Generate());
            //RuleFor(p => p.ShipAddress, f => addressFaker.Generate());

            Ignore(p => p.InvoiceAddress);
            Ignore(p => p.ShipAddress);
        }
    }
}
