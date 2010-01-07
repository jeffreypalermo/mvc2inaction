using System.Collections.Generic;
using System.Web.Mvc;
using DisplayModel.Models.Presentation;

namespace DisplayModel.Controllers
{
	// IOC?

	public class CustomerSummaryController : Controller
	{
		public ViewResult Index()
		{
			var customerSummaries = new CustomerSummaries();

			IEnumerable<CustomerSummary> summaries =
				customerSummaries.GetAll();

			return View(summaries);
		}
	}
}