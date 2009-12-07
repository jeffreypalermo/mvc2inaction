namespace DomainModel.Model
{
	public class OrderStatus
	{
		public static OrderStatus Canceled = new OrderStatus("Cancelled");
		public static OrderStatus Draft = new OrderStatus("Draft");
		public static OrderStatus Paid = new OrderStatus("Paid");
		public static OrderStatus Placed = new OrderStatus("Placed");
		public static OrderStatus Shipped = new OrderStatus("Shift");

		private OrderStatus(string text)
		{
			Text = text;
		}

		public string Text { get; private set; }
	}
}