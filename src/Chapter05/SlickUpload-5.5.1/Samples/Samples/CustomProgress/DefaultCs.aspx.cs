using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Krystalware.SlickUpload.Controls;
using System.Collections.Specialized;

public partial class CustomProgress_DefaultCs : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SlickUpload1.HideDuringUploadElements = "fileSelectText," + uploadButton.ClientID;
    }

    protected void SlickUpload1_UploadComplete(object sender, UploadStatusEventArgs e)
    {        
        uploadPanel.Visible = false;
        resultPanel.Visible = true;

        if (e.UploadedFiles != null && e.UploadedFiles.Count > 0)
        {
            // Simulate post processing
            Dictionary<string, string> status = new Dictionary<string, string>();

            for (int i = 0; i < 100; i++)
            {
                status["percentComplete"] = i.ToString();
                status["percentCompleteText"] = i.ToString() + "%";

                // Update the progress context
                e.Status.UpdatePostProcessStatus(status);

                System.Threading.Thread.Sleep(100);
            }

            status["percentComplete"] = "100";
            status["percentCompleteText"] = "100 %";

            // Update the progress context as complete
            e.Status.UpdatePostProcessStatus(status);

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
