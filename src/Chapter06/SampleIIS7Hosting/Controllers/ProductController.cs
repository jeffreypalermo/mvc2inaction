using System.Linq;
using System.Web.Mvc;
using SampleIIS7Hosting.Models;

namespace SampleIIS7Hosting.Controllers
{
    public class ProductController : Controller
    {
        private static readonly Product[] Products =
            new[]
                {
                    new Product
                        {
                            Id = 1,
                            Name = "Basketball",
                            Description = "You bounce it."
                        },
                    new Product
                        {
                            Id = 2,
                            Name = "Baseball",
                            Description = "You throw it."
                        },
                    new Product
                        {
                            Id = 3,
                            Name = "Football",
                            Description = "You punt it."
                        },
                    new Product
                        {
                            Id = 4,
                            Name = "Golf ball",
                            Description = "You hook or slice it."
                        }
                };

        public ActionResult List()
        {
            ViewData["Products"] = Products;

            return View();
        }

        public ActionResult Show(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);

            ViewData["Product"] = product;

            return View();
        }
    }
}