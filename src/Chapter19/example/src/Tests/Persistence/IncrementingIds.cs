using Core.Domain;
using NUnit.Framework;

namespace Tests.Persistence
{
   public class IncrementingIds : PersistenceTest
   {
      [Test]
      public void Should_increment_ids()
      {
         var order = new Order();

         store.Store(order);
         store.Store(order);
         Assert.That(order.Id, Is.EqualTo(1));

         var order1 = new Order();
         store.Store(order1);
         order1.Product = "foo";
         store.Store(order1);
         Assert.That(order1.Id, Is.EqualTo(2));

         var d = new dummy();
         store.Store(d);
         Assert.That(d.Id, Is.EqualTo(1));

         d = new dummy();
         store.Store(d);
         Assert.That(d.Id, Is.EqualTo(2));
      }

      internal class dummy : Entity
      {
         
      }
   }
}