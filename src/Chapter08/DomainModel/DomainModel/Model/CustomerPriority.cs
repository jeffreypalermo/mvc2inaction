namespace DomainModel.Model
{
	public class CustomerPriority
	{
		public static CustomerPriority Delinquent = new CustomerPriority("Delinquent");
		public static CustomerPriority Normal = new CustomerPriority("Normal");
		public static CustomerPriority Preferred = new CustomerPriority("Preferred");

		private CustomerPriority(string text)
		{
			Text = text;
		}

		public string Text { get; private set; }
	}
}