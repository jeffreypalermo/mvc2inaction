using System.Collections.Generic;
using System.Web.Mvc;
using UITesting.Core.Domain;
using UITesting.Core.Services;
using UITesting.Models;

namespace UITesting.Controllers
{
	public class ProductController : Controller
	{
		private readonly IProductRepository _productRepository;

		public ProductController(IProductRepository productRepository)
		{
			_productRepository = productRepository;
		}

		public ActionResult Index()
		{
			var products = _productRepository.FindAll();

			return new AutoMapResult<ProductListModel[]>(View(products));
		}

        public ActionResult Edit(int id)
		{
			var product = _productRepository.GetById(id);

			return new AutoMapResult<ProductForm>(View(product));
		}

		[HttpPost]
		public ActionResult Edit(ProductForm form)
		{
			if(! ModelState.IsValid) {
				return View("Edit", form);
			}

			var product = _productRepository.GetById(form.Id);

			product.Name = form.Name;
			product.Model = form.Model;
			product.Sku = form.Sku;
			product.Price = form.Price;

			_productRepository.Save(product);

			return RedirectToAction("Index");
		}
	}
}