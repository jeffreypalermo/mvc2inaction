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
            foreach (PropertyInfo property in modelList.GetType().GetElementType().GetProperties())
            {
                sb.AppendFormat("{0},",property.Name);                
            }
            sb.NewLine();
            foreach (object modelItem in modelList)
            {
                foreach (PropertyInfo info in modelList.GetType().GetElementType().GetProperties())
                {
                    object value = info.GetValue(modelItem, new object[0]);
                    sb.AppendFormat("{0},", value);
                }
                sb.NewLine();
            }
            return sb.AsBytes();
        }
    }
}