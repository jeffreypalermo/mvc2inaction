using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

using Krystalware.SlickUpload.Configuration;
using Krystalware.SlickUpload.Streams;
using System.IO;

public class FileIconHandlerCS : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        string ext = context.Request.QueryString["ext"] ?? "xxx";

        string fileName = context.Server.MapPath("~/Common/icons/" + ext + ".gif");

        if (!File.Exists(fileName))
            fileName = context.Server.MapPath("~/Common/icons/xxx.gif");

        context.Response.ContentType = "image/gif";
        context.Response.TransmitFile(fileName);
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}
