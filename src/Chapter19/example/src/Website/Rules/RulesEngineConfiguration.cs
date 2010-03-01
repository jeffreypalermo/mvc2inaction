using System;
using AutoMapper;
using CommandProcessor;
using Microsoft.Practices.ServiceLocation;
using Tarantino.RulesEngine.CommandProcessor;
using Website.Rules.MessageDefinitions;

namespace Website.Rules
{
   public class RulesEngineConfiguration
   {
      public static void Configure(Type typeToLocatorConfigurationAssembly)
      {
         var rulesEngine = new CommandProcessor.RulesEngine();
         CommandProcessor.RulesEngine.MessageProcessorFactory = new MessageProcessorFactory();
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