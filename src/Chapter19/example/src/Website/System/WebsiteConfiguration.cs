using System.Web;
using AutoMapper;
using Core;
using Core.Handlers;
using MvcContrib.CommandProcessor;
using MvcContrib.CommandProcessor.Commands;
using Persistence;
using Persistence.Db4o;
using StructureMap;
using StructureMap.Configuration.DSL;
using Website.ActionResults;

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
         ConfigureAutoMapper();
         AutoMappedViewResult.Map = Mapper.Map;
         ObjectFactory.GetInstance<TestDataCreator>().ResetTestData();
      }

      public static void ConfigureAutoMapper()
      {
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