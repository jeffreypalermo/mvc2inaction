using System;
using Core.Domain;
using Db4objects.Db4o;

namespace Persistence
{
   public class TestDataCreator
   {
      readonly IObjectContainer _store;

      public TestDataCreator(IObjectContainer store)
      {
         _store = store;
      }

      public void ResetTestData()
      {
         var order0 = CreateOrder("Coke Zero", 5, OrderStatus.Shipped, DateTime.Parse("2010-02-09"));
         _store.Store(order0);

         var order1 = CreateOrder("Jack's Insanity Sauce", 8, OrderStatus.Placed, null);
         _store.Store(order1);

         var order2 = CreateOrder("Diet Pepsi", 15, OrderStatus.Placed, null);
         _store.Store(order2);

         var order3 = CreateOrder("ASP.NET MVC 2 In Action", 16, OrderStatus.Placed, null);
         _store.Store(order3);

		 var order4 = CreateOrder("NHibernate In Action", 23, OrderStatus.Returned, DateTime.Parse("2009-03-15"));
         _store.Store(order4);

         var order5 = CreateOrder("Cuties California Clementines®", 42, OrderStatus.Placed, null);
         _store.Store(order5);

         _store.Commit();
      }

      Order CreateOrder(string product, int quantity, OrderStatus status, DateTime? shipDate)
      {
         return new Order
                   {
                      Product = product,
                      Quantity = quantity,
                      Status = status,
                      ShipDate = shipDate
                   };
      }
   }
}