using System.Collections.Generic;

namespace DomainModel.Model
{
	public class Customer : Entity
	{
		private readonly IList<Order> _orders = new List<Order>();

		public string Name { get; set; }
		public Address BillingAddress { get; set; }
		public Address ShippingAddress { get; set; }
		public CustomerPriority Priority { get; set; }

		public IEnumerable<Order> Orders
		{
			get { return _orders; }
		}

		public Order DraftOrder()
		{
			var order = new Order
			            	{
			            		Customer = this,
			            		Status = OrderStatus.Draft
			            	};
			_orders.Add(order);
			return order;
		}
	}
}