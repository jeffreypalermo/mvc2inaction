using System;
using SmartBindersExample.Models;

namespace SmartBindersExample.Helpers
{
	public static class IoC
	{
		public static object Resolve(Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IRepository<>))
			{
				return Activator.CreateInstance(typeof(ProfileRepository));
			}
			return null;
		}
		
		public static object Resolve<T>()
		{
			return null;
		}
	}
}