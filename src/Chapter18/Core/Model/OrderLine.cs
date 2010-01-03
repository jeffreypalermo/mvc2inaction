using Core;
using Core.Model;

namespace Core
{
	public class OrderLine : Entity
	{
		public Product Product { get; set; }
		public int Quantity { get; set; }

		public decimal GetPrice()
		{
			return Product.Price*Quantity;
		}
	}
}