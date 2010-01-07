using System.Web.Mvc;
using InputModel.Models;

namespace InputModel.Controllers
{
	public class CustomerController : Controller
	{
		public ViewResult New()
		{
			return View();
		}

        public ViewResult Save(NewCustomerInput input)
        {
            return View(input);
        }
	}
}