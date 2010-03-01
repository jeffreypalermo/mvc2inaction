using System.Linq;
using Core.Domain;

namespace Core.Interfaces
{
   public interface IDataQuery
   {
      IQueryable<T> Query<T>();
      T ById<T>(long id) where T : Entity;
   }
}