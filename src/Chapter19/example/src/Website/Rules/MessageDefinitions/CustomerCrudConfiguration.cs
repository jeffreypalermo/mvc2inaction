using Core.Messages;
using Tarantino.RulesEngine.Configuration;
using Website.Models;

namespace Website.Rules.MessageDefinitions
{
   public class CustomerCrudConfiguration : MessageDefinition<CustomerInput>
   {
      public CustomerCrudConfiguration()
      {
         Execute<SaveCustomer>();
      }
   }
}