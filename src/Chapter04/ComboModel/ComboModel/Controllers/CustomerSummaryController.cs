using System.Collections.Generic;
using System.Web.Mvc;
using ComboModel.Models;

namespace ComboModel.Controllers
{
	public class CustomerSummaryController : Controller
	{
		public ViewResult Index()
		{
			var customerSummaries = new CustomerSummaries();

			IEnumerable<CustomerSummary> summaries =
				customerSummaries.GetAll();

			return View(summaries);
		}

		public ViewResult Save(List<CustomerSummaryInput> input)
		{
			return View(input);
		}
	}

	public class CustomerSummaries
	{
		public IEnumerable<CustomerSummary> GetAll()
		{
			return new[]
			       	{
			       		new CustomerSummary
			       			{
			       				Active = true,
			       				FirstName = "John",
			       				LastName = "Smith",
			       				MostRecentOrderDate = "02/07/10",
			       				Number = 4,
			       				OrderCount = "42",
			       				ServiceLevel = "Standard"
			       			},
			       		new CustomerSummary
			       			{
			       				Active = false,
			       				FirstName = "Susan",
			       				LastName = "Power",
			       				MostRecentOrderDate = "02/02/10",
			       				Number = 5,
			       				OrderCount = "1",
			       				ServiceLevel = "Standard"
			       			},
			       		new CustomerSummary
			       			{
			       				Active = true,
			       				FirstName = "Jim",
			       				LastName = "Doe",
			       				MostRecentOrderDate = "02/09/10",
			       				Number = 6,
			       				OrderCount = "7",
			       				ServiceLevel = "Premier"
			       			},
			       	};
		}
	}
}