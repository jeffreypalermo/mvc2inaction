using System.Web.Mvc;
using WithAutomapper.Models;

namespace WithAutomapper.Controllers
{
	public class CustomerController : Controller
	{
public AutoMappedViewResult Index()
{
	var customer = GetCustomer();

	return AutoMappedView<CustomerInfo>(customer);
}

public AutoMappedViewResult AutoMappedView<TModel>(object Model)
{
	ViewData.Model = Model;
	return new AutoMappedViewResult(typeof (TModel))
	       	{
	       		ViewData = ViewData,
	       		TempData = TempData
	       	};
}

		public static Customer GetCustomer()
		{
			return new Customer
			       	{
			       		Name = new Name {First = "John", Last = "Doe"}
			       	};
		}
	}
}