using System.Linq;
using Core.Domain;
using Core.Interfaces;
using Tarantino.RulesEngine;
using Tarantino.RulesEngine.CommandProcessor;

namespace Core.Handlers
{
   public class SaveCustomerHandler : Command<SaveCustomerCommand>
   {
      readonly IDataStore _store;

      public SaveCustomerHandler(IDataStore store)
      {
         _store = store;
      }

      protected override ReturnValue Execute(SaveCustomerCommand commandMessage)
      {
         var customer = new Customer
                           {
                              EmailAddress = commandMessage.EmailAddress,
                              Name = commandMessage.Name,
                              PhoneNumber = commandMessage.PhoneNumber,
                           };

         _store.Store(customer);

         return new ReturnValue().SetValue(customer);
      }
   }
}