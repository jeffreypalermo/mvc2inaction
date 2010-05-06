using AutoMapper;

namespace WithAutomapper.Models
{
	public class AutoMapperConfiguration
	{
		public static void Configure()
		{
			Mapper.Initialize(x => x.AddProfile<ExampleProfile>());
		}


		public static void ConfigureBrokenExample()
		{
			Mapper.Initialize(x => x.AddProfile<BrokenProfile>());
		}
	}

	public class Destination
	{
		public string Name { get; set; }
		public string Typo { get; set; }
	}

	public class Source
	{
		public string Name { get; set; }
		public int Number { get; set; }
	}

	public class BrokenProfile : Profile
	{
		protected override void Configure()
		{
			CreateMap<Source, Destination>();
		}
	}
}