using MvcContrib.PortableAreas;

namespace RssWidgetPortableArea.Areas.RssWidget.Controllers
{
    public class RssWidgetRenderedMessage : IEventMessage
    {
        public string Url { get; set; }
    }
}