using System.Web.Mvc;

namespace SimpleRefactoring.Controllers
{
   //here for example only.  This controller will not run
   //(no views, interface implementations, or controller factory)
   public class OrderController : Controller
   {
      readonly IEmailSender _emailSender;
      readonly IOrderMessageBuilder _messageBuilder;
      readonly IOrderRepository _repository;
      readonly IShippingService _shippingService;
      readonly IUserSession _userSession;

      public OrderController(IOrderRepository repository,
                             IUserSession userSession,
                             IShippingService shippingService,
                             IOrderMessageBuilder orderMessageBuilder,
                             IEmailSender emailSender)
      {
         _repository = repository;
         _userSession = userSession;
         _shippingService = shippingService;
         _messageBuilder = orderMessageBuilder;
         _emailSender = emailSender;
      }

      public RedirectToRouteResult Ship(int orderId)
      {
         var user = _userSession.GetCurrentUser();
         var order = _repository.GetById(orderId);

         if (order.IsAuthorized)
         {
            var status = _shippingService.Ship(order);

            if (!string.IsNullOrEmpty(user.EmailAddress))
            {
               var message = _messageBuilder
                  .BuildShippedMessage(order, user);

               _emailSender.Send(message);
            }

            if (status.Successful)
            {
               return RedirectToAction("Shipped", "Order", new {orderId});
            }
         }
         return RedirectToAction("NotShipped", "Order", new {orderId});
      }
}

   public class LightweightOrderController : Controller
   {
      readonly IOrderShippingService _orderShippingService;

      public LightweightOrderController(IOrderShippingService orderShippingService)
      {
         _orderShippingService = orderShippingService;
      }

      public RedirectToRouteResult Ship(int orderId)
      {
         var status = _orderShippingService.Ship(orderId);
         if (status.Successful)
         {
            return RedirectToAction("Shipped", "Order", new {orderId});
         }
         return RedirectToAction("NotShipped", "Order", new {orderId});
      }
   }

   public interface IOrderShippingService
   {
      ShippingStatus Ship(int orderId);
   }

   public class ShippingStatus
   {
      public bool Successful;
   }

   public class Message
   {
   }

   public interface IUserSession
   {
      User GetCurrentUser();
   }

   public class User
   {
      public string EmailAddress;
   }

   public interface IOrderMessageBuilder
   {
      Message BuildShippedMessage(Order order, User user);
   }

   public interface IShippingService
   {
      ShippingStatus Ship(Order order);
   }

   public interface IOrderRepository
   {
      Order GetById(int id);
   }

   public class Order
   {
      public bool IsAuthorized;
   }

   public interface IEmailSender
   {
      void Send(Message message);
   }
}