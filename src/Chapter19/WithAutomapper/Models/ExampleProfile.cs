using AutoMapper;

namespace WithAutomapper.Models
{
	public class ExampleProfile : Profile
	{
		protected override string ProfileName
		{
			get { return "ViewModel"; }
		}

		protected override void Configure()
		{
			AddFormatter<HtmlEncoderFormatter>();

			CreateMap<Customer, CustomerInfo>();
		}
	}
}