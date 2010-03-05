using AutoMapper;
using NUnit.Framework;
using WithAutomapper.Models;

namespace WithAutomapper.Tests
{
	[TestFixture]
	public class AutoMapperConfigurationTester
	{
		[Test]
		public void Example_of_failing_configuration()
		{
			AutoMapperConfiguration.ConfigureBrokenExample();

			Mapper.AssertConfigurationIsValid();
		}

		[Test]
		public void Should_map_dtos()
		{
			AutoMapperConfiguration.Configure();

			Mapper.AssertConfigurationIsValid();
		}
	}
}