using System;
using System.Web;

namespace SampleIIS6WithISAPIFilter
{
    public class IIS6ExtensionRewriteModule : IHttpModule
    {
        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        void context_BeginRequest(object sender, EventArgs e)
        {
            string url = "~" + HttpContext.Current.Request.Url.PathAndQuery;
            if (url.Contains(".mvc"))
            {
                string newUrl = url.Replace(".mvc", "");
                HttpContext.Current.RewritePath(newUrl);
            }
        }
    }
}
