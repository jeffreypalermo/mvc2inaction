using System.Text;
using Core.Model;

namespace ViewModel.Models
{
	public interface ICustomerInfoMapper
	{
		CustomerInfo MapFrom(Customer customer);
	}

	public class CustomerInfoMapper : ICustomerInfoMapper
	{
		public CustomerInfo MapFrom(Customer customer)
		{
			return new CustomerInfo
			       	{
			       		Id = customer.Id,
			       		Name = new NameFormatter()
			       			.Format(customer.Name),
			       		ShippingAddress = new AddressFormatter()
			       			.Format(customer.ShippingAddress),
			       		Status = customer.Status ?? string.Empty,
			       		TotalAmountPaid = customer.GetTotalAmountPaid()
			       			.ToString("c")
			       	};
		}
	}

	public class AddressFormatter
	{
		public string Format(Address value)
		{
			if (value == null) return string.Empty;

			string withSecondLine = string.Format("{0}<br/>{1}<br/>{2}, {3} {4}",
			                                      value.Line1, value.Line2, value.City, value.State, value.Zip);
			string withoutSecondLine = string.Format("{0}<br/>{1}, {2} {3}",
			                                         value.Line1, value.City, value.State, value.Zip);
			string address = string.IsNullOrEmpty(value.Line2) ? withoutSecondLine : withSecondLine;
			address = string.IsNullOrEmpty(value.Line1) ? string.Empty : address;

			return address;
		}
	}

	public class NameFormatter
	{
		public string Format(Name value)
		{
			var sb = new StringBuilder();

			if (value == null) return string.Empty;

			if (!string.IsNullOrEmpty(value.First))
			{
				sb.Append(value.First);
			}

			if (!string.IsNullOrEmpty(value.Middle))
			{
				sb.Append(" " + value.Middle);
			}

			if (!string.IsNullOrEmpty(value.Last))
			{
				sb.Append(" " + value.Last);
			}

			if (value.Suffix != null)
			{
				sb.Append(", " + value.Suffix.DisplayName);
			}

			return sb.ToString();
		}
	}
}