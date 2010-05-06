using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using System.Web.Routing;
using System.Web.UI;

namespace RoutingWithWebForms
{
    public class CustomRouteHandler : IRouteHandler
    {
        public string VirtualPath { get; private set; }
        public string QueryString { get; private set; }

        public CustomRouteHandler(string virtualPath, string queryString)
        {
            this.VirtualPath = virtualPath;
            this.QueryString = queryString;
        }

        public IHttpHandler GetHttpHandler(RequestContext requestContext)
        {
            requestContext.HttpContext.RewritePath(string.Format("{0}?{1}", VirtualPath, QueryString));
            var page = BuildManager.CreateInstanceFromVirtualPath(VirtualPath, typeof (Page));
            return page as IHttpHandler;
        }
    }
}
