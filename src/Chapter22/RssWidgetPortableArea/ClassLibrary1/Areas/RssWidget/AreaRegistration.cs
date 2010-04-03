using System.Web.Mvc;
using MvcContrib.PortableAreas;

namespace RssWidgetPortableArea.Areas.RssWidget
{
    public class RssWidgetAreaRegistration : PortableAreaRegistration
    {
        public override string AreaName
        {
            get { return "RssWidget"; }
        }

        public override void RegisterArea(AreaRegistrationContext context, IApplicationBus bus)
        {
            context.MapRoute(
                "RssWidget_default",
                "RssWidget/{controller}/{action}/{id}",
                new {action = "Index", id = ""});
            base.RegisterTheViewsInTheEmbeddedViewEngine(GetType());
        }
    }
}