using ControllerFactories.Models;
using StructureMap.Configuration.DSL;

namespace ControllerFactories
{
    internal class MyStructureMapApplicationRegistry : Registry
    {
        protected override void configure()
        {
            //wire up IMessageProvider => StructureMapMessageProvider
            ForRequestedType<IMessageProvider>()
                .TheDefaultIsConcreteType<StructureMapMessageProvider>();
        }
    }
}