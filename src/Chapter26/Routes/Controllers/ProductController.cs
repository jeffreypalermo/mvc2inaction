using System.Web.Mvc;
using Routes.Models;

namespace Routes.Controllers
{
    public class ProductController : Controller
    {
        public ViewResult Index()
        {
            var products =
                new[]
                    {
                        new Product {Name = "DVD Player"},
                        new Product {Name = "VCR"},
                        new Product {Name = "Laserdisc Player"}
                    };
            return View(products);
        }

        public ViewResult Show(int id)
        {
            return View(new Product {Name = "Hand towels"});
        }

        public ViewResult Search(string name)
        {
            return View("Show", new Product {Name = name});
        }
    }
}