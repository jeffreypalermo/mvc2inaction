using System;
using AutoMapper;

namespace WithAutomapper.Models
{
	public abstract class BaseFormatter<T> : IValueFormatter
	{
		public string FormatValue(ResolutionContext context)
		{
			if (context.SourceValue == null)
				return null;

			if (!(context.SourceValue is T))
				return ToNullSafeString(context.SourceValue);

			return FormatValueCore((T) context.SourceValue);
		}

		private static string ToNullSafeString(object value)
		{
			return value == null ? String.Empty : value.ToString();
		}

		protected abstract string FormatValueCore(T value);
	}
}