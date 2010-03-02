using Core.Domain;

namespace Core.Interfaces
{
   public interface IRepository
   {
      void Save<T>(T obj);
      T GetById<T>(long id) where T : Entity;
   }

   public class Repository : IRepository
   {
      readonly IDataQuery _query;
      readonly IDataStore _store;

      public Repository(IDataQuery query, IDataStore store)
      {
         _query = query;
         _store = store;
      }

      public void Save<T>(T obj)
      {
         _store.Store(obj);
      }

      public T GetById<T>(long id) where T : Entity
      {
         return _query.ById<T>(id);
      }
   }
}