using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Krystalware.SlickUpload;
using Krystalware.SlickUpload.Status;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SlickUpload1_UploadComplete(object sender, Krystalware.SlickUpload.Controls.UploadStatusEventArgs e)
    {
        uploadResult.Text = "Upload Result: " + e.Status.State;

        if (e.Status.State == UploadState.Terminated)
            uploadResult.Text += ". Reason: " + e.Status.Reason;

        if (e.Status.State != UploadState.Terminated)
        {
            uploadFileList.DataSource = e.UploadedFiles;
            uploadFileList.DataBind();
        }
    }
}