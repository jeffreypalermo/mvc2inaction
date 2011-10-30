using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ModelState
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode,
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

        }

protected void Application_Start()
{
    RegisterRoutes(RouteTable.Routes);

    ModelMetadataProviders.Current = new ConventionProvider();
}
    }

public class ConventionProvider :
    DataAnnotationsModelMetadataProvider
{
    protected override ModelMetadata CreateMetadata(
        IEnumerable<Attribute> attributes,
        Type containerType,
        Func<object> modelAccessor,
        Type modelType,
        string propertyName)
    {
        var meta = base.CreateMetadata(attributes, containerType, modelAccessor, modelType, propertyName);
        if (meta.DisplayName == null)
            meta.DisplayName = meta.PropertyName.ToSeparatedWords();
        return meta;
    }
}
}

