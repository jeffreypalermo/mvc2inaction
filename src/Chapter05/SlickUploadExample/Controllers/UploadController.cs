using System.Web.Mvc;
using Krystalware.SlickUpload;
using Krystalware.SlickUpload.Controls;
using Krystalware.SlickUpload.Status;

namespace SlickUploadExample.Controllers
{
    public class UploadController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

public ActionResult UploadResult()
{
    UploadStatus status = UploadConnector.GetUploadStatus();

    return View(status);
}

    }
}