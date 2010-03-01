using System.Collections.Generic;
using System.Web.Mvc;
using ServerControls.Models;

namespace ServerControls.Controllers
{
    public class DemoController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult TextBox()
        {
            return View();
        }

        public ActionResult Grid()
        {
            var customers = new[]
                {
                    new Customer("Bob", "Barker", "111-222-3456"),
                    new Customer("Joe", "Dimaggio", "222-333-4567"),
                    new Customer("John", "Candy", "333-444-5678"),
                    new Customer("Betty", "White", "444-555-6789")
                }; 
           
            return View(customers);
        }

        public ActionResult Menu()
        {
            return View();
        }
    }
}