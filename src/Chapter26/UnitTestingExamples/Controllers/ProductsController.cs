using System.Web.Mvc;
using UnitTestingExamples.Models;
using UnitTestingExamples.Services;

namespace UnitTestingExamples.Controllers
{


    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(
            IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        //In reality you'd use an inversion of control container to supply the dependency.
        public ProductsController()
            : this(new ProductRepository())
        {
        }

        public ViewResult Index()
        {
            Product[] products = _productRepository.FindAll();

            return View(products);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }
            _productRepository.Save(product);

            return RedirectToAction("index");
        }
    }
}