namespace Core.Model
{
	public class Name
	{
		public Name(string first, string last)
		{
			First = first;
			Last = last;
		}

		public string First { get; set; }
		public string Middle { get; set; }
		public string Last { get; set; }
		public Suffix Suffix { get; set; }
	}
}