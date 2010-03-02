using Db4objects.Db4o;
using Persistence.Db4o;
using StructureMap.Configuration.DSL;

namespace Persistence
{
   public class PersistenceConfiguration : Registry
   {
      public PersistenceConfiguration()
      {
         For<ContainerFactory>().Use<ContainerFactory>().EnumerableOf<IDb4oConvention>()
            .Contains(x => x.Type<IncremementEntityIds>());

         For<IPersistence>().Use<ContainerFactory>();

         For<IObjectContainer>().Singleton().Use(x => x.GetInstance<ContainerFactory>().GetContainer());
      }
   }
}