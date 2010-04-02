using Core.Domain;
using Core.Interfaces;
using Core.Messages;
using MvcContrib.CommandProcessor;
using MvcContrib.CommandProcessor.Commands;
using MvcContrib.CommandProcessor.Validation;

namespace Core.Handlers
{
   public class ShipOrderHandler : Command<ShipOrder>
   {
      readonly IRepository _repository;

      public ShipOrderHandler(IRepository repository)
      {
         _repository = repository;
      }

      protected override ReturnValue Execute(ShipOrder commandMessage)
      {
         var order = _repository.GetById<Order>(commandMessage.OrderId);

         order.Ship();

         _repository.Save(order);

         return new ReturnValue().SetValue(order);
      }
   }

   public class OrderIsPlaced : ValidationRule<ShipOrder>
   {
      readonly IRepository _repository;

      public OrderIsPlaced(IRepository repository)
      {
         _repository = repository;
      }

      protected override string IsValidCore(ShipOrder input)
      {
         var order = _repository.GetById<Order>(input.OrderId);

         if (order.Status == OrderStatus.Placed)
            return Success();

         return "Order must be in \"Placed\" status";
      }
   }
}