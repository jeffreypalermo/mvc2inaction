using System.Web;
using AutoMapper;
using CommandProcessor;
using Core.Handlers;
using Persistence;
using StructureMap;
using StructureMap.Configuration.DSL;
using Tarantino.RulesEngine.CommandProcessor;

namespace Website.System
{
   public class WebsiteConfiguration : Registry
   {
      public WebsiteConfiguration()
      {
         For<HttpContextBase>().Use(
            x => HttpContext.Current == null ? null : new HttpContextWrapper(HttpContext.Current));

         Scan(s =>
                 {
                    s.AssemblyContainingType<WebsiteConfiguration>();
                    s.AssemblyContainingType<PersistenceConfiguration>();
                    s.AssemblyContainingType<SaveCustomerHandler>();
                    s.AssemblyContainingType<RulesEngine>();
                    s.WithDefaultConventions();
                    s.LookForRegistries();
                    s.ConnectImplementationsToTypesClosing(typeof (Command<>));
                 });
      }

      public static void Initialize()
      {
         ObjectFactory.Initialize(x => x.AddRegistry<WebsiteConfiguration>());
         Mapper.Initialize(x =>
                              {
                                 x.AddProfile<RulesProfile>();
                                 x.AddProfile<WebsiteProfile>();
                              });
      }

      public static void CleanUp()
      {
         ObjectFactory.GetInstance<IPersistence>().Dispose();
         ObjectFactory.ResetDefaults();
      }
   }
}