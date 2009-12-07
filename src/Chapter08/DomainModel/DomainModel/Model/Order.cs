using System.Collections.Generic;
using System.Linq;

namespace DomainModel.Model
{
	public class Order : Entity
	{
		private readonly IList<OrderLine> _orderLines = new List<OrderLine>();
		public Customer Customer { get; set; }
		public OrderStatus Status { get; set; }

		public IEnumerable<OrderLine> OrderLines
		{
			get { return _orderLines; }
		}

		public decimal GetTotalPrice()
		{
			return _orderLines.Sum(x => x.Price);
		}

		public void AddProductToOrder(Product product, int quantity)
		{
			var line = new OrderLine
			           	{
			           		Quantity = quantity,
			           		Price = product.Price,
			           		Product = product
			           	};

			_orderLines.Add(line);
		}

		public void RemoveProductFromOrder(Product product)
		{
			IEnumerable<OrderLine> productLines =
				_orderLines.Where(x => x.Product == product);
			foreach (OrderLine line in productLines)
			{
				_orderLines.Remove(line);
			}
		}
	}
}