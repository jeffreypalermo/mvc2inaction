using System.Collections.Generic;
using System.Web.Mvc;
using Core;
using Core.Model;

namespace BeforeAutomapper.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ICustomerRepository _repository;

		public CustomerController() : this(new CustomerRepository())
		{
		}

		public CustomerController(ICustomerRepository repository)
		{
			_repository = repository;
		}

		public ViewResult Index()
		{
			IEnumerable<Customer> customers = _repository.GetAll();
			return View(customers);
		}

		public ViewResult Show(int id)
		{
			Customer customer = _repository.GetById(id);
			return View(customer);
		}
	}
}