namespace Core.Model
{
	public class OrderStatus : Enumeration
	{
		public static OrderStatus Draft = new OrderStatus(1, "Draft");
		public static OrderStatus Placed = new OrderStatus(2, "Paid");
		public static OrderStatus Shipped = new OrderStatus(3, "Shipped");

		public OrderStatus()
		{
		}

		public OrderStatus(int value, string displayName) : base(value, displayName)
		{
		}
	}
}