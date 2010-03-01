using Db4objects.Db4o;
using StructureMap.Configuration.DSL;

namespace Persistence
{
   public class PersistenceConfiguration : Registry
   {
      public PersistenceConfiguration()
      {
         For<IPersistence>().Use<ContainerFactory>();
         Scan(x => x.AddAllTypesOf<IDb4oConvention>());
         For<IObjectContainer>().Singleton().Use(x => x.GetInstance<ContainerFactory>().GetContainer());
      }
   }
}