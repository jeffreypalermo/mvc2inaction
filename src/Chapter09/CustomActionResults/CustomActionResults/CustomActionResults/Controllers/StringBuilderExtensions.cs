using System;
using System.Linq;
using System.Text;

namespace CustomActionResults.Controllers
{
    public static class StringBuilderExtensions
    {
        public static void NewLine(this StringBuilder stringBuilder)
        {
            stringBuilder.Remove(stringBuilder.Length - 1, 1);
            stringBuilder.Append(Environment.NewLine);
        }
        public static byte[] AsBytes(this StringBuilder stringBuilder)
        {
            return stringBuilder.ToString().Select(c => Convert.ToByte((char) c)).ToArray();
        }
    }
}