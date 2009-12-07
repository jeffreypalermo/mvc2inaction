using System.Collections.Generic;

namespace DomainModel.Model
{
	public class Product : Entity
	{
		private readonly IList<ProductCategory> _categories = new List<ProductCategory>();
		public string Name { get; set; }
		public decimal Price { get; set; }

		public IEnumerable<ProductCategory> Categories
		{
			get { return _categories; }
		}

		public Supplier Supplier { get; set; }
	}
}