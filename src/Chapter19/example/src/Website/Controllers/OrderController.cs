using System;
using System.Linq;
using System.Web.Mvc;
using Core.Domain;
using Core.Interfaces;
using Website.ActionResults;
using Website.Models;

namespace Website.Controllers
{
   public class OrderController : CommandController
   {
      readonly IDataQuery _query;

      public OrderController(IDataQuery query)
      {
         _query = query;
      }

      public ViewResult Index()
      {
         var orders = from c in _query.Query<Order>()
                      orderby c.ShipDate ?? DateTime.MinValue descending
                      select c;

         return AutoMappedView<OrderInfo[]>(orders);
      }

      public CommandResult Ship(int orderId)
      {
         var message = new ShipOrderMessage {OrderId = orderId};
         return Command(message,
                        () => RedirectToAction("Shipped", new {orderId}),
                        () => RedirectToAction("NotShipped", new {orderId}));
      }

      public ViewResult Shipped(int orderId)
      {
         var order = _query.ById<Order>(orderId);
         return AutoMappedView<OrderInfo>(order);
      }

      public ViewResult NotShipped(int orderId)
      {
         var order = _query.ById<Order>(orderId);
         return AutoMappedView<OrderInfo>(order);
      }
   }
}