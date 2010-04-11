using System;
using System.Web;
using System.Web.Mvc;

using Krystalware.SlickUpload;
using Krystalware.SlickUpload.Controls;
using Krystalware.SlickUpload.Status;

namespace AspNetMvcCS
{
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
