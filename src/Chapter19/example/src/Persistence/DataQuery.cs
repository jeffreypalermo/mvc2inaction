using System.Linq;
using Core.Domain;
using Core.Interfaces;
using Db4objects.Db4o;
using Db4objects.Db4o.Linq;

namespace Persistence
{
   public class DataQuery : IDataQuery
   {
      readonly IObjectContainer _container;

      public DataQuery(IObjectContainer container)
      {
         _container = container;
      }

      public IQueryable<T> Query<T>()
      {
         return _container.AsQueryable<T>();
      }

      public T ById<T>(long id) where T : Entity
      {
         return (from t in Query<T>() where t.Id == id select t).Single();
      }
   }
}