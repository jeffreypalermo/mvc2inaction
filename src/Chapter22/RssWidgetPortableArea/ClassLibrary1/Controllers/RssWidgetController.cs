using System;
using System.Web.Mvc;
using MvcContrib.PortableAreas;

namespace RssWidgetPortableArea.Controllers
{
    public class RssWidgetController : Controller
    {
        public ActionResult Index(string RssUrl)
        {
            MvcContrib.Bus.Send(new RssWidgetRenderedMessage{Url = RssUrl});
            return View(new SyndicationService().GetFeed(RssUrl, 10));
        }
    }

    public class RssWidgetRenderedMessage : IEventMessage
    {
        public string Url { get; set; }
    }
}