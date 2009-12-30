namespace UITesting.Core.Domain
{
	public class Product : Entity
	{
		public string Name { get; set; }
		public string Model { get; set; }
		public string Sku { get; set; }
		public decimal Price { get; set; }

		public Manufacturer Manufacturer { get; set; }
	}
}