using System;
using System.Linq;
using AutoMapper;
using NUnit.Framework;
using WithAutomapper.Models;

namespace WithAutomapper.Tests
{
	[TestFixture]
	public class AutoMapperConfigurationTester
	{
		[Test]
		public void Should_map_dtos()
		{
			AutoMapperConfiguration.Configure();
			Mapper.AssertConfigurationIsValid();
		}
	}
}