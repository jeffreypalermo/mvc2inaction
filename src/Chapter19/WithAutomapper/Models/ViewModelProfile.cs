using AutoMapper;
using Core.Model;

namespace WithAutomapper.Models
{
	public class ViewModelProfile : Profile
	{
		protected override string ProfileName { get { return "ViewModel"; } }

		protected override void Configure()
		{
			AddFormatter<HtmlEncoderFormatter>();
			ForSourceType<Name>().AddFormatter<NameFormatter>();

			CreateMap<Customer, CustomerInfo>()
				.ForMember(x => x.ShippingAddress, opt =>
				                                   	{
				                                   		opt.AddFormatter<AddressFormatter>();
				                                   		opt.SkipFormatter<HtmlEncoderFormatter>();
				                                   	});
		}
	}
}