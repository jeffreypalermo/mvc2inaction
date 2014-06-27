using System;
using System.Diagnostics;
using System.Web;
using System.Web.Mvc;

namespace StateManagement.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly ICache _cache;

        public HomeController() : this(new AspNetCache())
        {
        }

        public HomeController(ICache cache)
        {
            _cache = cache;
        }

        public ActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About()
        {
            ViewData["Title"] = "About Page";

            return View();
        }


        public ActionResult CacheTest()
        {
            const string key = "test";

            if(!_cache.Exists(key))
            {
                _cache.Add(key, "value");
            }

            var message = _cache.Get<string>(key);

            return Content(message);
        }



        [OutputCache(Duration=100, VaryByParam="")]
        public ActionResult CurrentTime()
        {
            var now = DateTime.Now;
            ViewData["time"] = now.ToLongTimeString();
            return View();
        }


        public ActionResult ViewCart()
        {
            const string key = "shopping_cart";
            if(Session[key] == null)
                Session.Add(key, new Cart());

            var cart = (Cart) Session[key];

            return View(cart);
        }

        public ActionResult SetLocale(string locale)
        {
            var cookie = new HttpCookie("locale", locale);

            Response.Cookies.Add(cookie);
            return View();
        }
    }

    public class Cart
    {
    }


    public interface ICache
    {
        T Get<T>(string key);
        void Add(string key, object value);
        bool Exists(string key);
    }

    public class AspNetCache : ICache
    {
        public T Get<T>(string key)
        {
            return (T)HttpContext.Current.Cache[key];
        }

        public void Add(string key, object value)
        {
            HttpContext.Current.Cache.Insert(key, value);
        }

        public bool Exists(string key)
        {
            return HttpContext.Current.Cache.Get(key) != null;
        }
    }

}
