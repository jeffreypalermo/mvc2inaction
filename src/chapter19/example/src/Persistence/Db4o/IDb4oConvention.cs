using System;
using Core.Domain;
using Db4objects.Db4o;
using Db4objects.Db4o.Events;

namespace Persistence
{
   public interface IDb4oConvention
   {
      void Apply(IObjectServer server, IObjectContainer container);
   }

   public class IncremementEntityIds : IDb4oConvention
   {
      public void Apply(IObjectServer server, IObjectContainer container)
      {
         var registry = EventRegistryFactory.ForObjectContainer(container);
         registry.Creating += IncrementIds(server, container);
      }

      static EventHandler<CancellableObjectEventArgs> IncrementIds(IObjectServer server, IObjectContainer container)
      {
         // mostly taken from Tuna Toksoz' excellent article at http://tunatoksoz.com/post/Id-Generation-for-db4o.aspx
         return (sender, args) =>
                   {
                      var entity = args.Object as Entity;
                      if (entity != null)
                      {
                         var set = container.QueryByExample(new IncrementTypeValuePair {Type = args.Object.GetType()});
                         IncrementTypeValuePair pair;
                         if (set.Count == 0)
                            pair = new IncrementTypeValuePair {Type = args.Object.GetType()};
                         else
                            pair = (IncrementTypeValuePair) set[0];
                         entity.Id = ++pair.Value;
                         var client = server.OpenClient();
                         client.Store(pair);
                         client.Commit();
                      }
                   };
      }
   }
}