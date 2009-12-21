namespace Core.Model
{
	public class CustomerStatus : Enumeration
	{
		public static CustomerStatus Gold = new CustomerStatus(2, "Gold", 3);
		public static CustomerStatus Normal = new CustomerStatus(1, "Normal", 0);
		public static CustomerStatus Platinum = new CustomerStatus(3, "Platinum", 10);

		public CustomerStatus()
		{
		}

		public CustomerStatus(int value, string displayName, int percentDiscount) : base(value, displayName)
		{
			PercentDiscount = percentDiscount;
		}

		public int PercentDiscount { get; private set; }
	}
}