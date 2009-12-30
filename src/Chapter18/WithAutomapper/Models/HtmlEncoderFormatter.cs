using System;
using System.Web;
using AutoMapper;

namespace WithAutomapper.Models
{
	public class HtmlEncoderFormatter : IValueFormatter
	{
		public string FormatValue(ResolutionContext context)
		{
			return HttpUtility.HtmlEncode(ToNullSafeString(context.SourceValue));
		}

		private static string ToNullSafeString(object value)
		{
			return value == null ? String.Empty : value.ToString();
		}
	}
}