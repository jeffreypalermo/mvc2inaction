using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using Krystalware.SlickUpload.Controls;
using Krystalware.SlickUpload.Status;

namespace AspNetMvcCS.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Select files to upload";

            return View();
        }

        public ActionResult UploadResult(UploadStatus status)
        {
            return View(status);
        }
    }
}
