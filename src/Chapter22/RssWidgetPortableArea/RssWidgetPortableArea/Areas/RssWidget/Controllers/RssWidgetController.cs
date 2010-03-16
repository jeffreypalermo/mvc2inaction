using System;
using System.Web.Mvc;

namespace RssWidgetPortableArea.Areas.RssWidget.Controllers
{
    public class RssWidgetController : Controller
    {
        public ActionResult Index(string RssUrl)
        {
            MvcContrib.Bus.Send(new RssWidgetRenderedMessage{Url = RssUrl});
            return View(new SyndicationService().GetFeed(RssUrl, 10));
        }
    }
}