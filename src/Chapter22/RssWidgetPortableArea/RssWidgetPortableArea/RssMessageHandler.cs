namespace RssWidgetPortableArea 
{
	using MvcContrib.PortableAreas;
	using RssWidgetPortableArea.Areas.RssWidget.Controllers;

	public class RssMessageHandler : MessageHandler<RssWidgetRenderedMessage> 
	{
		public override void Handle(RssWidgetRenderedMessage message) 
		{
			//log the message to the application's log
		}
	}
}