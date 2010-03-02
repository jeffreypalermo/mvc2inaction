using System;

namespace Core.Domain
{
   public class Order : Entity
   {
      public Order()
      {
         Status = OrderStatus.Placed;
      }

      public string Product { get; set; }
      public int Quantity { get; set; }
      public OrderStatus Status { get; set; }
      public DateTime? ShipDate { get; set; }

      public void Ship()
      {
         Status = OrderStatus.Shipped;
         ShipDate = DateTime.Now;
      }
   }
}