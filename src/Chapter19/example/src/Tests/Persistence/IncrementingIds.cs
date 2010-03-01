using Core.Domain;
using NUnit.Framework;

namespace Tests.Persistence
{
   public class IncrementingIds : PersistenceTest
   {
      [Test]
      public void Should_increment_ids()
      {
         var customer = new Customer();

         store.Store(customer);
         store.Store(customer);
         Assert.That(customer.Id, Is.EqualTo(1));

         var customer1 = new Customer();
         store.Store(customer1);
         customer1.Name = "foo";
         store.Store(customer1);
         Assert.That(customer1.Id, Is.EqualTo(2));

         var d = new dummy();
         store.Store(d);
         Assert.That(d.Id, Is.EqualTo(1));
      }

      internal class dummy : Entity
      {
         
      }
   }
}