using System.Text;
using Core.Model;

namespace WithAutomapper.Models
{
public class NameFormatter : BaseFormatter<Name>
{
	protected override string FormatValueCore(Name value)
	{
		var sb = new StringBuilder();

		if (value == null) return string.Empty;

		if (!string.IsNullOrEmpty(value.First))
		{
			sb.Append(value.First);
		}

		if (!string.IsNullOrEmpty(value.Middle))
		{
			sb.Append(" " + value.Middle);
		}

		if (!string.IsNullOrEmpty(value.Last))
		{
			sb.Append(" " + value.Last);
		}

		if (value.Suffix != null)
		{
			sb.Append(", " + value.Suffix.DisplayName);
		}

		return sb.ToString();
	}
}
}