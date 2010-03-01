using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace Website.Rules
{
   public class StructureMapProvider : ServiceLocatorImplBase
   {
      protected override object DoGetInstance(Type serviceType, string key)
      {
         if (string.IsNullOrEmpty(key)) return ObjectFactory.GetInstance(serviceType);
         return ObjectFactory.GetNamedInstance(serviceType, key);
      }

      protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
      {
         return ObjectFactory.GetAllInstances(serviceType).Cast<object>();
      }
   }
}