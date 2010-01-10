using System.Collections.Generic;
using DisplayModel.Models.Presentation;

namespace DisplayModel.Controllers
{
	public class CustomerSummaries
	{
		public IEnumerable<CustomerSummary> GetAll()
		{
			return new[]
			       	{
			       		new CustomerSummary
			       			{
			       				Active = true,
								Name = "John Smith",
			       				MostRecentOrderDate = "02/07/10",
			       				OrderCount = "42",
			       				ServiceLevel = "Standard"
			       			},
			       		new CustomerSummary
			       			{
			       				Active = false,
			       				Name = "Susan Power",
			       				MostRecentOrderDate = "02/02/10",
			       				OrderCount = "1",
			       				ServiceLevel = "Standard"
			       			},
			       		new CustomerSummary
			       			{
			       				Active = true,
			       				Name = "Jim Doe",
			       				MostRecentOrderDate = "02/09/10",
			       				OrderCount = "7",
			       				ServiceLevel = "Premier"
			       			},
			       	};
		}
	}
}