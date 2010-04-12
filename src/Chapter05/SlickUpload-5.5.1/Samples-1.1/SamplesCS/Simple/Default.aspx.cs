using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Krystalware.SlickUpload.Controls;

namespace SamplesCS.Simple
{
	public class Default : System.Web.UI.Page
	{
		protected Krystalware.SlickUpload.Controls.SlickUpload SlickUpload1;
		protected System.Web.UI.WebControls.Button uploadButton;
		protected System.Web.UI.HtmlControls.HtmlGenericControl uploadPanel;
		protected System.Web.UI.WebControls.Repeater resultsRepeater;
		protected System.Web.UI.WebControls.Button newUploadButton;
		protected System.Web.UI.HtmlControls.HtmlGenericControl resultPanel;
	
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
				resultsRepeater.DataSource = e.UploadedFiles;
				resultsRepeater.DataBind();

				resultsRepeater.Visible = true;
			}
			else
			{
				resultsRepeater.Visible = false;
			}
		}

		private void InitializeComponent()
		{
		
		}

		protected void newUploadButton_Click(object sender, EventArgs e)
		{
			uploadPanel.Visible = true;
			resultPanel.Visible = false;
		}
	}
}