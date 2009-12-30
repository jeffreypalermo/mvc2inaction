using System;

namespace Core
{
	public class SystemTime
	{
		public static Func<DateTime> Now = () => DateTime.Now;
	}
}