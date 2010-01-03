using System.Web.Mvc;
using WithAutomapper.Models;
using WithAutomapper.Tests;

namespace WithAutomapper.Controllers
{
	public class CustomerController : Controller
	{
		public ActionResult Index()
		{
			Customer customer = GetCustomer();

			return new AutoMapResult<CustomerInfo>(View(customer));
		}

		private Customer GetCustomer()
		{
			return new Customer
			       	{
			       		Name = new Name {First = "John", Last = "Doe"}
			       	};
		}
	}
}