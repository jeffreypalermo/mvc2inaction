using System.Web.Mvc;

namespace UITesting.Models
{
	public class ProductForm
	{
		[HiddenInput(DisplayValue = false)]
		public int Id { get; set; }

		public string Name { get; set; }
		public string Model { get; set; }
		public string Sku { get; set; }
		public decimal Price { get; set; }
	}
}