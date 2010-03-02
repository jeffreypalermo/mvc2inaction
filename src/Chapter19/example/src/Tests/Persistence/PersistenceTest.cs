using System.IO;
using Core.Interfaces;
using Db4objects.Db4o;
using NUnit.Framework;
using Persistence;
using Persistence.Db4o;

namespace Tests.Persistence
{
   public class PersistenceTest
   {
      protected const string StorageFile = "test-storage-file";
      IObjectContainer container;
      ContainerFactory factory;
      protected IDataQuery query;
      protected IDataStore store;

      [SetUp]
      public void SetUp()
      {
         File.Delete(StorageFile);
         factory = new ContainerFactory(null, new IDb4oConvention[] {new IncremementEntityIds()});
         container = GetContainer();
         CreateDependencies(container);
      }

      void CreateDependencies(IObjectContainer objectContainer)
      {
         store = new DataStore(objectContainer);
         query = new DataQuery(objectContainer);
      }

      IObjectContainer GetContainer()
      {
         return factory.GetContainer(StorageFile);
      }

      protected void Recycle()
      {
         container.Commit();
         CreateDependencies(container);
      }

      [TearDown]
      public void TearDown()
      {
         container.Close();
         factory.Dispose();
      }
   }
}