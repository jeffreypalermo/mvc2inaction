using System;
using System.Collections.Generic;
using System.Linq;
using UITesting.Core.Domain;

namespace UITesting.Core.Services.Impl
{
	public class ProductRepository : IProductRepository
	{
		private static readonly IList<Product> _products = new List<Product>();
		private static readonly IList<Manufacturer> _manufacturers = new List<Manufacturer>();

		static ProductRepository()
		{
			Reset();
		}

		public static void Reset()
		{
			_products.Clear();
			_manufacturers.Clear();

			var insignia = new Manufacturer
			               {
			               	Id = 1,
			               	Name = "Insignia"
			               };
			var dynex = new Manufacturer
			            {
			            	Id = 2,
			            	Name = "Dynex"
			            };

			_manufacturers.Add(insignia);
			_products.Add(new Product
			              {
			              	Id = 1,
			              	Name = "Insignia® - 26\" Class / 720p / 60Hz / LCD HDTV DVD Combo",
			              	Model = "NS-LDVD26Q-10A",
			              	Sku = "9154764",
			              	Price = 359.99m,
			              	Manufacturer = insignia
			              });
			_products.Add(new Product
			              {
			              	Id = 2,
			              	Name = "Insignia® - 19\" Class / 720p / 60Hz / LCD HDTV",
			              	Model = "NS-L19Q-10A",
			              	Sku = "9182715",
			              	Price = 189.99m,
			              	Manufacturer = insignia
			              });
			_products.Add(new Product
			              {
			              	Id = 3,
			              	Name = "Dynex® - 15\" Class / 720p / 60Hz / LCD HDTV",
			              	Model = "DX-L15-10A",
			              	Sku = "9135376",
			              	Price = 159.99m,
			              	Manufacturer = dynex
			              });
		}

		public IEnumerable<Product> FindAll()
		{
			return _products;
		}

		public Product GetById(int id)
		{
			return _products.First(p => p.Id == id);
		}

		public void Save(Product product)
		{
			// No-op
		}
	}
}