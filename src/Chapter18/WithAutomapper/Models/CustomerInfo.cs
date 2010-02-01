namespace WithAutomapper.Models
{
	public class CustomerInfo
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Status { get; set; }
		public string TotalAmountPaid { get; set; }
		public string ShippingAddress { get; set; }
	}

	public class CustomerDestination
	{
		public string NameFirst { get; set; }
		public string NameLast { get; set; }
		public string TotalAmountPaid { get; set; }
		public OrderDestination[] ShippedOrders { get; set; }
	}

	public class OrderDestination
	{
		public string ShipDate { get; set; }
	}
}