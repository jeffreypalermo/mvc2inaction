using System.Web.Mvc;
using StructureMap;

namespace Website.Controllers
{
   public interface IBus
   {
      Result Send<T>(T message);
   }

   public class Bus : IBus
   {
      public Result Send<T>(T message)
      {
         var handler = ObjectFactory.GetInstance<IHandler<T>>();
         var result = handler.Handle(message);
         return result;
      }
   }

   public interface IHandler<T>
   {
      Result Handle(T message);
   }

   public class OrderShippingService :
      IHandler<ShipOrderMessage>
   {
      public Result Handle(ShipOrderMessage message)
      {
         var result = new Result();
         // ship order and indicate success
         return result;
      }
   }

   public interface IOrderShippingService
   {
   }

   public class Result
   {
      public bool Successful;
   }

   public class ExampleOrderController : Controller
   {
      readonly IBus _bus;

      public ExampleOrderController(IBus bus)
      {
         _bus = bus;
      }

      public ActionResult Ship(int orderId)
      {
         var message = new ShipOrderMessage
                          {
                             OrderId = orderId
                          };

         var result = _bus.Send(message);

         if (result.Successful)
         {
            return RedirectToAction
               ("Shipped", "Order", new {orderId});
         }
         return RedirectToAction
            ("NotShipped", "Order", new {orderId});
      }
   }

   public class ShipOrderMessage
   {
      public int OrderId;
   }
}