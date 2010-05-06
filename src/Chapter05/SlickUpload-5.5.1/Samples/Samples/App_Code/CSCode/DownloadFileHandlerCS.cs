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

public class DownloadFileHandlerCS : IHttpHandler
{
    public void ProcessRequest(HttpContext context)
    {
        int id = int.Parse(context.Request.QueryString["id"]);

        RepositoryFileCS file = RepositoryFileCS.GetById(id);

        context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        context.Response.AddHeader("Content-Length", file.Length.ToString());
        context.Response.ContentType = "application/octet-stream";

        using (Stream dataStream = file.GetDataStream())
        {
            byte[] buffer = new byte[8192];

            int read;

            while ((read = dataStream.Read(buffer, 0, 8192)) > 0)
                context.Response.OutputStream.Write(buffer, 0, read);
        }
    }

    public bool IsReusable
    {
        get
        {
            return true;
        }
    }
}
