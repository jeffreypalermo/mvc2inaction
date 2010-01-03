namespace WithAutomapper.Models
{
	public class Customer
	{
		public Name Name { get; set; }
	}

	public class Name
	{
		public string First { get; set; }
		public string Last { get; set; }
	}
}