using System.Collections.Generic;
using System.Web.Mvc;
using DisplayModel.Models.Presentation;

namespace DisplayModel.Controllers
{
	// IOC?

	public class CustomerSummaryController : Controller
	{
		private readonly CustomerSummaries _customerSummaries = new CustomerSummaries();

		public ViewResult Index()
		{
			IEnumerable<CustomerSummary> summaries =
				_customerSummaries.GetAll();

			return View(summaries);
		}
	}
}