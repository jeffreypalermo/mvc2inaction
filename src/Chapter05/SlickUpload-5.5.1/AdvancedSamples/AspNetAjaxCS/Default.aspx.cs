using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Krystalware.SlickUpload.Controls;

namespace AspNetAjaxCS
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void updateButton_Click(object sender, EventArgs e)
        {
            updateLabel.Text = DateTime.Now.ToLongTimeString();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            ExistingImagesRepeater.DataSource = new string[] {"test"};
            ExistingImagesRepeater.DataBind();
        }

        protected void ExistingImagesRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            fileSelector.Visible = fileList.Visible = true;

        }
    }
}
