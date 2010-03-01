using Core;
using Db4objects.Db4o;

namespace Persistence
{
   public class UnitOfWork : IUnitOfWork
   {
      readonly IObjectContainer _container;

      public UnitOfWork(IObjectContainer container)
      {
         _container = container;
      }

      public void Dispose()
      {
      }

      public void Begin()
      {
      }

      public void Commit()
      {
         _container.Commit();
      }

      public void RollBack()
      {
         _container.Rollback();
      }
   }
}