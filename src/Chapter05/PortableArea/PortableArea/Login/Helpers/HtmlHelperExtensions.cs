using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace PortableArea.Login.Helpers
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString LoginLink(this HtmlHelper helper)
        {
            return helper.Action("UserWidget", "Account", new { area = "login" });            
        }
    }
}