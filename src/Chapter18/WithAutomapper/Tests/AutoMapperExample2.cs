using System;
using AutoMapper;
using NUnit.Framework;

namespace WithAutomapper.Tests
{
	[TestFixture]
	public class AutoMapperExample2
	{
		public class Source
		{
			public Child Child { get; set; }
		}

		public class Child
		{
			public int Number { get; set; }
		}

		public class Destination
		{
			public string ChildNumber { get; set; }
		}

		[Test]
		public void Demonstration()
		{
			Mapper.CreateMap<Source, Destination>();
			var source = new Source
			             	{
			             		Child = new Child {Number = 3}
			             	};
			Destination desintation =
				Mapper.Map<Source, Destination>(source);
			Console.WriteLine(desintation.ChildNumber);
		}
	}
}