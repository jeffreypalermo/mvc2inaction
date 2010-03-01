using Core;
using Tarantino.RulesEngine.Configuration;
using Tarantino.RulesEngine.ValidationRules;
using Website.Models;

namespace Website.Rules.MessageDefinitions
{
   public class CustomerCrudConfiguration : MessageDefinition<CustomerInput>
   {
      public CustomerCrudConfiguration()
      {
         Execute<SaveCustomerCommand>();
      }
   }
}