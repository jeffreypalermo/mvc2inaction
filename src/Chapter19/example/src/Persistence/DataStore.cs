using Core.Interfaces;
using Db4objects.Db4o;

namespace Persistence
{
   public class DataStore : IDataStore
   {
      readonly IObjectContainer _container;

      public DataStore(IObjectContainer container)
      {
         _container = container;
      }

      public void Store(object obj)
      {
         _container.Store(obj);
      }
   }
}