using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Krystalware.SlickUpload.Controls;

public partial class Overview_DefaultCs : System.Web.UI.Page
{
    protected void Page_PreRender(object sender, EventArgs e)
    {
        settingsBox.Style["display"] = uploadPanel.Visible ? "" : "none";

        maxFilesTextBox.Text = SlickUpload1.MaxFiles.ToString();
        validExtensionsTextBox.Text = SlickUpload1.ValidExtensions;
        invalidExtensionMessageTextBox.Text = SlickUpload1.InvalidExtensionMessage;

        requiredFilesValidator.Enabled = requireFileCheckBox.Checked;

        extensionValidator.Text = validationSummaryMessageTextBox.Text;
        extensionValidator.Enabled = !string.IsNullOrEmpty(validExtensionsTextBox.Text) && !string.IsNullOrEmpty(validationSummaryMessageTextBox.Text);

        maxFilesSpan.InnerText = SlickUpload1.MaxFiles.ToString();
        requireFileSpan.InnerText = requireFileCheckBox.Checked ? "Yes" : "No";
        confirmNavigateSpan.InnerText = SlickUpload1.ConfirmNavigateDuringUploadMessage;
        validExtensionsSpan.InnerText = SlickUpload1.ValidExtensions;
        invalidExtensionMessageSpan.InnerText = SlickUpload1.InvalidExtensionMessage;
        validationSummaryMessageSpan.InnerText = validationSummaryMessageTextBox.Text;

        string onSave = "kw.get('" + SlickUpload1.ClientID + "').clear();Page_BlockSubmit=false;";

        saveSettingsButton.OnClientClick = onSave;
        cancelSettingsButton.OnClientClick = onSave;
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

    protected void saveSettingsButton_Click(object sender, EventArgs e)
    {
        int maxFiles;

        if (!int.TryParse(maxFilesTextBox.Text, out maxFiles))
            maxFiles = -1;

        SlickUpload1.MaxFiles = maxFiles;
        SlickUpload1.ConfirmNavigateDuringUploadMessage = confirmNavigateTextBox.Text;
        SlickUpload1.ValidExtensions = validExtensionsTextBox.Text;
        SlickUpload1.InvalidExtensionMessage = invalidExtensionMessageTextBox.Text;
    }
}
