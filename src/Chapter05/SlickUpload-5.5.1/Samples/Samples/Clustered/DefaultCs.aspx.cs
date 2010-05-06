using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Krystalware.SlickUpload.Controls;
using Krystalware.SlickUpload.Configuration;
using Krystalware.SlickUpload.Status;

public partial class Clustered_DefaultCs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SlickUpload1.HideDuringUploadElements = "fileSelectText," + uploadButton.ClientID;

        // REMOVE FOR APPLICATION CODE
        // Only for sample, to catch exception if the sql connection isn't properly specified.
        try
        {
            SqlClientStatusManager sm = new SqlClientStatusManager(SlickUploadConfiguration.StatusManager);

            sm.RemoveStaleStatus(1000);

            SlickUpload1.Visible = true;
            uploadButton.Visible = true;

            errorMessage.Visible = false;
        }
        catch (Exception ex)
        {
            SlickUpload1.Visible = false;
            uploadButton.Visible = false;

            errorMessage.InnerHtml += ex.GetType().FullName + ": " + ex.Message;
            errorMessage.Visible = true;
        }
    }

    protected void SlickUpload1_UploadComplete(object sender, UploadStatusEventArgs e)
    {
        uploadPanel.Visible = false;
        resultPanel.Visible = true;

        if (e.UploadedFiles != null && e.UploadedFiles.Count > 0)
        {
            resultsRepeater.DataSource = e.UploadedFiles;
            resultsRepeater.DataBind();

            resultsRepeater.Visible = true;
        }
        else
        {
            resultsRepeater.Visible = false;
        }
    }

    protected void newUploadButton_Click(object sender, EventArgs e)
    {
        uploadPanel.Visible = true;
        resultPanel.Visible = false;
    }
}
