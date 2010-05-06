using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using Db4objects.Db4o;
using Db4objects.Db4o.CS;

namespace Persistence.Db4o
{
   public class ContainerFactory : IPersistence
   {
      public const string StorageFile = "storage.yam";
      readonly IEnumerable<IDb4oConvention> _conventions;
      readonly HttpContextBase _httpContext;
      IObjectServer server;

      public ContainerFactory(HttpContextBase httpContext, IEnumerable<IDb4oConvention> conventions)
      {
         _httpContext = httpContext;
         _conventions = conventions;
      }

      public void Dispose()
      {
         if (server != null)
            server.Close();
      }

      public IObjectContainer GetContainer()
      {
         var websiteFileName = GetFilename();

         if (File.Exists(websiteFileName))
         {
            File.Delete(websiteFileName);
         }

         return GetContainer(websiteFileName);
      }

      public IObjectContainer GetContainer(string filename)
      {
         OpenServer(filename);

         var container = server.OpenClient();

         foreach (var convention in _conventions)
         {
            convention.Apply(server, container);
         }

         return container;
      }

      void OpenServer(string filename)
      {
         server = Db4oClientServer.OpenServer(filename, 0);
      }

      string GetFilename()
      {
         if (_httpContext == null)
         {
            return StorageFile;
         }
         return Path.Combine(_httpContext.Server.MapPath("~/App_Data"), StorageFile);
      }
   }

   public interface IPersistence : IDisposable
   {
   }
}