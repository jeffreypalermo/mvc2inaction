using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Krystalware.SlickUpload.Controls;

namespace SamplesCS.Overview
{
	public class Default : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox maxFilesTextBox;
		protected System.Web.UI.WebControls.CheckBox requireFileCheckBox;
		protected System.Web.UI.WebControls.TextBox validExtensionsTextBox;
		protected System.Web.UI.WebControls.TextBox invalidExtensionMessageTextBox;
		protected System.Web.UI.WebControls.TextBox validationSummaryMessageTextBox;
		protected System.Web.UI.WebControls.Button saveSettingsButton;
		protected System.Web.UI.WebControls.Button cancelSettingsButton;
		protected Krystalware.SlickUpload.Controls.SlickUpload SlickUpload1;
		protected System.Web.UI.WebControls.CustomValidator requiredFilesValidator;
		protected System.Web.UI.WebControls.CustomValidator extensionValidator;
		protected System.Web.UI.HtmlControls.HtmlGenericControl uploadPanel;
		protected System.Web.UI.WebControls.Repeater resultsRepeater;
		protected System.Web.UI.WebControls.Button newUploadButton;
		protected System.Web.UI.HtmlControls.HtmlGenericControl resultPanel;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl settingsBox;
		protected System.Web.UI.HtmlControls.HtmlGenericControl maxFilesSpan;
		protected System.Web.UI.HtmlControls.HtmlGenericControl requireFileSpan;
		protected System.Web.UI.HtmlControls.HtmlGenericControl validExtensionsSpan;
		protected System.Web.UI.HtmlControls.HtmlGenericControl invalidExtensionMessageSpan;
		protected System.Web.UI.HtmlControls.HtmlGenericControl validationSummaryMessageSpan;
		protected System.Web.UI.HtmlControls.HtmlGenericControl Div1;

		protected void Page_PreRender(object sender, EventArgs e)
		{
			settingsBox.Style["display"] = uploadPanel.Visible ? "block" : "none";

			maxFilesTextBox.Text = SlickUpload1.MaxFiles.ToString();
			validExtensionsTextBox.Text = SlickUpload1.ValidExtensions;
			invalidExtensionMessageTextBox.Text = SlickUpload1.InvalidExtensionMessage;

			requiredFilesValidator.Enabled = requireFileCheckBox.Checked;

			extensionValidator.Text = validationSummaryMessageTextBox.Text;
			extensionValidator.Enabled = validExtensionsTextBox.Text != null && validExtensionsTextBox.Text.Length > 0 &&
				validationSummaryMessageTextBox.Text != null && validationSummaryMessageTextBox.Text.Length > 0;

			maxFilesSpan.InnerText = SlickUpload1.MaxFiles.ToString();
			validExtensionsSpan.InnerText = SlickUpload1.ValidExtensions;
			invalidExtensionMessageSpan.InnerText = SlickUpload1.InvalidExtensionMessage;
			requireFileSpan.InnerText = requireFileCheckBox.Checked ? "Yes" : "No";
			validationSummaryMessageSpan.InnerText = validationSummaryMessageTextBox.Text;

			saveSettingsButton.Attributes["onclick"] = cancelSettingsButton.Attributes["onclick"] = "kw.get('" + SlickUpload1.ClientID + "').clear();Page_BlockSubmit=false;";
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

		private void InitializeComponent()
		{

		}

		protected void saveSettingsButton_Click(object sender, EventArgs e)
		{
			int maxFiles;

			try
			{
				maxFiles = int.Parse(maxFilesTextBox.Text);
			}
			catch
			{
				maxFiles = -1;
			}

			SlickUpload1.MaxFiles = maxFiles;
			SlickUpload1.ValidExtensions = validExtensionsTextBox.Text;
			SlickUpload1.InvalidExtensionMessage = invalidExtensionMessageTextBox.Text;
		}
	}
}