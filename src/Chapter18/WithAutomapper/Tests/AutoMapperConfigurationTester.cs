using AutoMapper;
using NUnit.Framework;
using WithAutomapper.Models;

namespace WithAutomapper.Tests
{
	[TestFixture]
	public class AutoMapperConfigurationTester
	{
		public void Should_map_everything()
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