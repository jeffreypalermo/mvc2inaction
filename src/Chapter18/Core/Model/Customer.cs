using System.Collections.Generic;
using System.Linq;

namespace Core.Model
{
public class Customer
{
	public Name Name { get; set; }
    public IEnumerable<Order> GetShippedOrders()
	{
		// gets shipped orders
	}
    public decimal GetTotalAmountPaid()
	{
		// gets total amount paid
	}

		private readonly ICollection<Order> _orders = new HashSet<Order>();
		public IEnumerable<Order> Orders
		{
			get { return _orders; }
		}

		public CustomerStatus Status { get; set; }

		public void AddOrder(Order order)
		{
			order.Customer = this;
			_orders.Add(order);
		}


				public Address ShippingAddress { get; set; }
	}
}