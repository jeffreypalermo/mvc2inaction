using Core.Domain;
using Core.Interfaces;
using Core.Messages;
using MvcContrib.CommandProcessor;
using MvcContrib.CommandProcessor.Commands;

namespace Core.Handlers
{
   public class SaveCustomerHandler : Command<SaveCustomer>
   {
      readonly IDataStore _store;

      public SaveCustomerHandler(IDataStore store)
      {
         _store = store;
      }

      protected override ReturnValue Execute(SaveCustomer message)
      {
         var customer = new Customer
                           {
                              EmailAddress = message.EmailAddress,
                              Name = message.Name,
                              PhoneNumber = message.PhoneNumber,
                           };

         _store.Store(customer);

         return new ReturnValue().SetValue(customer);
      }
   }
}