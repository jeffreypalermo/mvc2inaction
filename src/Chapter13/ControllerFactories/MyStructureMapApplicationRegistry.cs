using ControllerFactories.Models;
using StructureMap.Configuration.DSL;

namespace ControllerFactories
{
    internal class MyStructureMapApplicationRegistry : Registry
    {
    	public MyStructureMapApplicationRegistry() {
			//wire up IMessageProvider => StructureMapMessageProvider
			For<IMessageProvider>()
				.Use<StructureMapMessageProvider>();
    	}
    }
}