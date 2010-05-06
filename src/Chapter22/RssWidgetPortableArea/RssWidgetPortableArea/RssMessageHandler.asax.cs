using MvcContrib.PortableAreas;
using RssWidgetPortableArea.Areas.RssWidget.Controllers;

namespace RssWidgetPortableArea
{
    public class RssMessageHandler : MessageHandler<RssWidgetRenderedMessage>
    {
        public override void Handle(RssWidgetRenderedMessage message)
        {
            //log the message to the applications log.
        }
    }
}