using System.Collections;
using System.Reflection;
using System.Text;

namespace CustomActionResults.Controllers
{
    public class CsvFileCreator
    {
        public byte[] AsBytes(IEnumerable modelList)
        {
            StringBuilder sb = new StringBuilder();
            BuildHeaders(modelList, sb);
            BuildRows(modelList, sb);
            return sb.AsBytes();
        }

        private void BuildRows(IEnumerable modelList, StringBuilder sb)
        {
            foreach (object modelItem in modelList)
            {
                BuildRowData(modelList, modelItem, sb);
                sb.NewLine();
            }
        }

        private void BuildRowData(IEnumerable modelList, object modelItem, StringBuilder sb)
        {
            foreach (PropertyInfo info in modelList.GetType().GetElementType().GetProperties())
            {
                object value = info.GetValue(modelItem, new object[0]);
                sb.AppendFormat("{0},", value);
            }
        }

        private void BuildHeaders(IEnumerable modelList, StringBuilder sb)
        {
            foreach (PropertyInfo property in modelList.GetType().GetElementType().GetProperties())
            {
                sb.AppendFormat("{0},",property.Name);
            }
            sb.NewLine();
        }
    }
}