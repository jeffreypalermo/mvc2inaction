using Core.Handlers;
using Core.Messages;
using MvcContrib.CommandProcessor.Configuration;
using Website.Controllers;

namespace Website.Rules.MessageDefinitions
{
   public class ShipOrderConfiguration : MessageDefinition<ShipOrderMessage>
   {
      public ShipOrderConfiguration()
      {
         Execute<ShipOrder>()
            .Enforce(r => r.Rule<OrderIsPlaced>());
      }
   }
}