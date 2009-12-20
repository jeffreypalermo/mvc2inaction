using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Core;
using Core.Model;
using ViewModel.Models;

namespace ViewModel.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ICustomerInfoMapper _mapper;
		private readonly ICustomerRepository _repository;

		public CustomerController() : this(new CustomerRepository(), new CustomerInfoMapper())
		{
		}

		public CustomerController(ICustomerRepository repository, ICustomerInfoMapper mapper)
		{
			_repository = repository;
			_mapper = mapper;
		}

		public ViewResult Index()
		{
			IEnumerable<Customer> customers = _repository.GetAll();
			IEnumerable<CustomerInfo> models = customers.Select(x => _mapper.MapFrom(x));
			return View(models);
		}

		public ViewResult Show(int id)
		{
			Customer customer = _repository.GetById(id);
			CustomerInfo model = _mapper.MapFrom(customer);
			return View(model);
		}
	}
}