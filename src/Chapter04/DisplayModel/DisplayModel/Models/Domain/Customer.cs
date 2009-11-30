using System.Collections.Generic;
using System.Linq;

namespace DisplayModel.Models.Domain
{
	public class Customer
	{
		public int Number { get; set; }
		public Name Name { get; set; }
		public bool Active { get; set; }
		public ServiceLevel ServiceLevel { get; set; }
		public IEnumerable<Order> Orders { get; set; }

		public Order GetMostRecentOrder()
		{
			if (Orders == null)
				return null;

			return Orders.OrderByDescending(order => order.Date).FirstOrDefault();
		}
	}
}