using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Model
{
	public class Order : Entity
	{
		private readonly ICollection<OrderLine> _lines = new HashSet<OrderLine>();

		public Order(Customer customer)
		{
			Status = OrderStatus.Draft;
			Customer = customer;
			customer.AddOrder(this);
		}

		public Order()
		{
		}

		public IEnumerable<OrderLine> OrderLines
		{
			get { return _lines; }
		}

		public OrderStatus Status { get; set; }
		public Customer Customer { get; set; }
		public DateTime? PlaceDate { get; set; }
		public DateTime ShipDate { get; set; }

		public void Place()
		{
			if (Status == OrderStatus.Shipped || Status == OrderStatus.Placed) return;

			PlaceDate = SystemTime.Now();
			Status = OrderStatus.Placed;
		}

		public void Ship()
		{
			if (Status == OrderStatus.Shipped || Status == OrderStatus.Draft) return;

			ShipDate = SystemTime.Now();
			Status = OrderStatus.Shipped;
		}

		public decimal GetPrice()
		{
			decimal linePrice = OrderLines.Sum(x => x.GetPrice());
			decimal customerDiscount = ((decimal) Customer.Status.PercentDiscount/100);
			return linePrice - customerDiscount*linePrice;
		}

		public void AddOrderLine(int quantity, Product product)
		{
			var line = new OrderLine{Product = product, Quantity = quantity};
			_lines.Add(line);
		}
	}
}