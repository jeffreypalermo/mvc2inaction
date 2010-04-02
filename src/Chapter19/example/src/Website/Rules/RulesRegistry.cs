using StructureMap.Configuration.DSL;
using Website.Rules.Adapters;

namespace Website.Rules
{
   public class RulesRegistry : Registry
   {
      public RulesRegistry()
      {
         For<MvcContrib.CommandProcessor.Interfaces.IUnitOfWork>().Use<UnitOfWorkAdapter>();
         RulesEngineConfiguration.Configure();
      }
   }
}