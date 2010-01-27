using System.Collections.Generic;
using System.Linq;

namespace Core.Model
{
	public class Customer : Entity
	{
		private readonly ICollection<Order> _orders = new HashSet<Order>();

		public Name Name { get; set; }


		public IEnumerable<Order> Orders
		{
			get { return _orders; }
		}

		public CustomerStatus Status { get; set; }
		public Address ShippingAddress { get; set; }

		public void AddOrder(Order order)
		{
			order.Customer = this;
			_orders.Add(order);
		}

		public IEnumerable<Order> GetShippedOrders()
		{
			return Orders.Where(x => x.Status == OrderStatus.Shipped);
		}

		public decimal GetTotalAmountPaid()
		{
			return GetShippedOrders().Sum(x => x.GetPrice());
		}
	}
}