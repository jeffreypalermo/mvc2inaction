using StructureMap.Configuration.DSL;
using Tarantino.RulesEngine.CommandProcessor;
using Website.Rules.Adapters;

namespace Website.Rules
{
   public class RulesRegistry : Registry
   {
      public RulesRegistry()
      {
         For<Tarantino.RulesEngine.IUnitOfWork>().Use<UnitOfWorkAdapter>();
         RulesEngineConfiguration.Configure();
      }
   }
}