using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Core;
using Core.Model;
using WithAutomapper.Controllers;

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
		ForSourceType<Name>().AddFormatter<NameFormatter>();
		ForSourceType<decimal>()
			.AddFormatExpression(context => 
				((decimal)context.SourceValue).ToString("c"));

		CreateMap<Customer, CustomerInfo>()
			.ForMember(x => x.ShippingAddress, opt =>
			{
				opt.AddFormatter<AddressFormatter>();
				opt.SkipFormatter<HtmlEncoderFormatter>();
			});
	}
}
//		private static void CreateSelectList(Customer customer, CustomerInput input)
//		{
//			IEnumerable<CustomerStatus> allCustomerStatuses = Enumeration.GetAll<CustomerStatus>();
//			int selectedValue = customer.Status.Value;
//			input.AllStatuses = new SelectList(allCustomerStatuses, "Value", "DisplayName", selectedValue);
//		}
//	}
}