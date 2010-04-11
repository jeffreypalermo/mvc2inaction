﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Krystalware.SlickUpload;
using Krystalware.SlickUpload.Controls;
using Krystalware.SlickUpload.Status;

namespace SlickUploadExample
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            UploadStatusModelBinder.Register(ModelBinders.Binders);
        }
    }

    public class UploadStatusModelBinder : IModelBinder
    {
        public static void Register(ModelBinderDictionary modelBinders)
        {
            if (!modelBinders.ContainsKey(typeof(UploadStatus)))
                modelBinders.Add(typeof(UploadStatus), new UploadStatusModelBinder());
        }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            UploadStatus status = HttpUploadModule.GetUploadStatus() ?? UploadConnector.GetUploadStatus();

            return status;
        }
    }

}