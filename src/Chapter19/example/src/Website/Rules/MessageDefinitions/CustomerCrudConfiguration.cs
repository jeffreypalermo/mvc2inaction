using Core.Messages;
using MvcContrib.CommandProcessor.Configuration;
using Website.Models;

namespace Website.Rules.MessageDefinitions
{
   public class CustomerCrudConfiguration : 
		MessageDefinition<CustomerInput>
   {
      public CustomerCrudConfiguration()
      {
         Execute<SaveCustomer>();
      }
   }
}