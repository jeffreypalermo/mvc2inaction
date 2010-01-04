using System.Collections.Generic;
using System.Web.Mvc;
using Core;
using Core.Model;
using WithAutomapper.Models;

namespace WithAutomapper.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ICustomerRepository _repository;
		public CustomerController()
			: this(new CustomerRepository())
		{
		}

		public CustomerController(ICustomerRepository repository)
		{
			_repository = repository;
		}

		[AutoMapModel(typeof(IEnumerable<Customer>), typeof(IEnumerable<CustomerInfo>))]
		public ViewResult Index()
		{
			IEnumerable<Customer> customers = _repository.GetAll();
			return View(customers);
		}

		[AutoMapModel(typeof(Customer), typeof(CustomerInfo))]
		public ViewResult Show(int id)
		{
			Customer customer = _repository.GetById(id);
			return View(customer);
		}

		[AutoMapModel(typeof(Customer), typeof(CustomerInput))]
		public ViewResult Edit(int id)
		{
			Customer customer = _repository.GetById(id);
			return View(customer);
		}
	}

	public class CustomerInput
	{
		public string NameFirst { get; set; }
		public string NameLast { get; set; }

		public string StatusValue { get; set; }

		public SelectList AllStatuses { get; set; }
	}
}