using AutoMapper;
using NUnit.Framework;
using StructureMap;
using Website.System;

namespace Tests
{
   public class StructureMapTests
   {
      [Test]
      public void Test_everything()
      {
         WebsiteConfiguration.Initialize();
         ObjectFactory.AssertConfigurationIsValid();
         WebsiteConfiguration.CleanUp();
      }
   }

   public class AutoMapperTests
   {
      [Test]
      public void Test_mappings()
      {
         WebsiteConfiguration.ConfigureAutoMapper();
         Mapper.AssertConfigurationIsValid();
      }
   }
}