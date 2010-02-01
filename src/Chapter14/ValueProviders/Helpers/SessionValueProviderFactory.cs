using System;
using System.Web.Mvc;

namespace ValueProvidersExample.Helpers
{
public class SessionValueProviderFactory : ValueProviderFactory
{
    public override IValueProvider GetValueProvider(
        ControllerContext controllerContext)
    {
        return new SessionValueProvider(
            controllerContext.HttpContext.Session);
    }
}
}