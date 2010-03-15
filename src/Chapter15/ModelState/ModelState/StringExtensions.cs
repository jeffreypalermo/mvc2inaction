using System.Text.RegularExpressions;

namespace ModelState
{
public static class StringExtensions
{
    public static string ToSeparatedWords(this string value)
    {
        if (value != null)
            return Regex.Replace(value, "([A-Z][a-z]?)", " $1").Trim();
        return value;
    }
}
}