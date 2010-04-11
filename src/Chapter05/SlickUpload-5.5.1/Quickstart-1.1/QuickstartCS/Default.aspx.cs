using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Krystalware.SlickUpload;
using Krystalware.SlickUpload.Status;
using Krystalware.SlickUpload.Controls;

namespace QuickstartCS
{
	public class Default : System.Web.UI.Page
	{
		protected Krystalware.SlickUpload.Controls.SlickUpload SlickUpload1;
		protected System.Web.UI.WebControls.Button Button1;
		protected System.Web.UI.WebControls.Button cancelButton;
		protected System.Web.UI.WebControls.Label uploadResult;
		protected System.Web.UI.WebControls.Repeater uploadFileList;

		private void InitializeComponent()
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
}