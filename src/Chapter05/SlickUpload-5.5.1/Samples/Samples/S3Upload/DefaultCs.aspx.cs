using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Krystalware.SlickUpload.Controls;
using System.Collections.Specialized;
using Affirma.ThreeSharp.Query;
using Affirma.ThreeSharp;
using System.Configuration;
using Krystalware.SlickUpload;
using Affirma.ThreeSharp.Model;
using Krystalware.SlickUpload.Providers;
using System.IO;
using System.Threading;

public partial class S3Upload_DefaultCs : System.Web.UI.Page
{
    ThreeSharpQuery _q;
    Exception _s3Exception;

    protected void Page_Load(object sender, EventArgs e)
    {
        SlickUpload1.HideDuringUploadElements = "fileSelectText," + uploadButton.ClientID;

        ThreeSharpConfig cfg = new ThreeSharpConfig();

        cfg.AwsAccessKeyID = ConfigurationManager.AppSettings["awsAccessKeyId"];
        cfg.AwsSecretAccessKey = ConfigurationManager.AppSettings["awsSecretAccessKey"];

        _q = new ThreeSharpQuery(cfg);
    }

    protected void SlickUpload1_UploadComplete(object sender, UploadStatusEventArgs e)
    {        
        uploadPanel.Visible = false;
        resultPanel.Visible = true;

        if (e.UploadedFiles != null && e.UploadedFiles.Count > 0)
        {
            Dictionary<string, string> status = new Dictionary<string, string>();

            status["percentComplete"] = "0";
            status["percentCompleteText"] = "0%";

            // Update the progress context
            e.Status.UpdatePostProcessStatus(status);

            string bucket = ConfigurationManager.AppSettings["awsBucket"];

            long totalLength = 0;
            long transferredLength = 0;

            // Calculate total length
            foreach (UploadedFile uFile in e.UploadedFiles)
                totalLength += uFile.ContentLength;

            // Upload each file
            foreach (UploadedFile uFile in e.UploadedFiles)
            {
                string fileName = uFile.LocationInfo[FileUploadStreamProvider.FileNameKey];

                using (ObjectAddRequest req = new ObjectAddRequest(bucket, Server.UrlEncode(uFile.ClientName)))
                {
                    req.LoadStreamWithFile(fileName);

                    // Create and fire up a new thread to do the actual upload
                    Thread t = new Thread(UploadThread);

                    t.Start(req);

                    while (t.IsAlive && req.BytesTransferred < req.BytesTotal)
                    {
                        float percentComplete = ((transferredLength + req.BytesTransferred) / (float)totalLength);

                        status["percentComplete"] = (percentComplete * 100).ToString("f2");
                        status["percentCompleteText"] = percentComplete.ToString("p2");

                        // Update the progress context
                        e.Status.UpdatePostProcessStatus(status);

                        // wait 500ms
                        Thread.Sleep(500);
                    }
                }

                transferredLength += uFile.ContentLength;

                File.Delete(fileName);
            }

            status["percentComplete"] = "100";
            status["percentCompleteText"] = "100 %";

            // Update the progress context
            e.Status.UpdatePostProcessStatus(status, true);

            resultsRepeater.DataSource = e.UploadedFiles;
            resultsRepeater.DataBind();

            resultsRepeater.Visible = true;

            if (_s3Exception != null)
            {
                errorMessage.InnerHtml += _s3Exception.GetType().FullName + ": " + _s3Exception.Message;
                errorMessage.Visible = true;
            }
        }
        else
        {
            resultsRepeater.Visible = false;
        }
    }

    void UploadThread(object data)
    {
        try
        {
            ObjectAddRequest req = (ObjectAddRequest)data;

            using (ObjectAddResponse resp = _q.ObjectAdd(req))
            { }
        }
        catch (Exception ex)
        {
            _s3Exception = ex;
        }
    }

    protected void newUploadButton_Click(object sender, EventArgs e)
    {
        uploadPanel.Visible = true;
        resultPanel.Visible = false;
    }
}
