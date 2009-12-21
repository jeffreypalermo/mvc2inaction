namespace Core.Model
{
	public class Suffix : Enumeration
	{
		public static Suffix I = new Suffix(3, "I");
		public static Suffix II = new Suffix(4, "II");
		public static Suffix III = new Suffix(5, "III");
		public static Suffix IV = new Suffix(6, "IV");
		public static Suffix JR = new Suffix(1, "JR");
		public static Suffix SR = new Suffix(2, "SR");
		public static Suffix V = new Suffix(7, "V");
		public static Suffix VI = new Suffix(8, "VI");
		public static Suffix VII = new Suffix(9, "VII");

		public Suffix()
		{
		}

		public Suffix(int value, string displayName)
			: base(value, displayName)
		{
		}
	}
}