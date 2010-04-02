using System;
using AutoMapper;
using Microsoft.Practices.ServiceLocation;
using MvcContrib.CommandProcessor;
using Website.Rules.MessageDefinitions;

namespace Website.Rules
{
   public class RulesEngineConfiguration
   {
      public static void Configure(Type typeToLocatorConfigurationAssembly)
      {
         var rulesEngine = new RulesEngine();
         RulesEngine.MessageProcessorFactory = new MessageProcessorFactory();
         rulesEngine.Initialize(typeToLocatorConfigurationAssembly.Assembly, new MessageMapper());
         ServiceLocator.SetLocatorProvider(() => new StructureMapProvider());
      }

      public static void Configure()
      {
         Configure(typeof (CustomerCrudConfiguration));
      }

      public class MessageMapper : IMessageMapper
      {
         public object MapUiMessageToCommandMessage(object message, Type messageType, Type destinationType)
         {
            return Mapper.Map(message, message.GetType(), destinationType);
         }
      }
   }
}