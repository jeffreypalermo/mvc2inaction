using System.Linq;
using System.Web.Mvc;
using Core.Domain;
using Core.Interfaces;
using Website.ActionResults;
using Website.Models;

namespace Website.Controllers
{
   public class CustomerController : CommandController
   {
      readonly IDataQuery _query;

      public CustomerController(IDataQuery query)
      {
         _query = query;
      }

      public ViewResult New()
      {
         return View("Edit");
      }

      public ViewResult Edit(long id)
      {
         var customer = _query.ById<Customer>(id);
         return View("Edit", customer);
      }

      public ViewResult Index()
      {
         var customers = from c in _query.Query<Customer>()
                         orderby c.Name
                         select c;

         return View(customers);
      }

      public CommandResult Save(CustomerInput input)
      {
         return Command(input, 
				() => RedirectToAction<CustomerController>(x => x.Index()), 
				() => View("Edit"));
      }
   }
}