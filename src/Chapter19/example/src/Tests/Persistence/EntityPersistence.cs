using Core.Domain;
using NUnit.Framework;
using System.Linq;

namespace Tests.Persistence
{
   public class EntityPersistence : PersistenceTest
   {
      [Test]
      public void Should_persist_customer()
      {
         var customer = new Customer
                           {
                              EmailAddress = "joe@example.com",
                              Name = "joe",
                              PhoneNumber = "817-555-1212"
                           };

         store.Store(customer);

         Recycle();

         var reloadedCustomer = query.ById<Customer>(1);

         Assert.That(reloadedCustomer, Is.EqualTo(customer));
      }

      [Test]
      public void Should_query_with_linq()
      {
         var customer = new Customer{Name = "john", EmailAddress = "joe@example.com", PhoneNumber = "800"};
         var customer1 = new Customer{Name = "john", EmailAddress = "john@example.com", PhoneNumber = "800"};

         store.Store(customer);
         store.Store(customer1);
         store.Store(new Customer{Name = "joe", EmailAddress = "joe@example.com", PhoneNumber = "800"});
         store.Store(new Customer{Name = "john", EmailAddress = "joe@example.com", PhoneNumber = "801"});

         Recycle();

         var customers = query.Query<Customer>().Where(x => x.PhoneNumber == "800" && x.Name == "john").ToList();

         CollectionAssert.Contains(customers, customer);
         CollectionAssert.Contains(customers, customer1);
         Assert.That(customers.Count(), Is.EqualTo(2));
      }
   }
}