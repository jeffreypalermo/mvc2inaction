Imports Krystalware.SlickUpload.Controls

Partial Class Overview_DefaultVB
    Inherits System.Web.UI.Page

    Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles Me.PreRender
        settingsBox.Style("display") = IIf(uploadPanel.Visible, "", "none")

        maxFilesTextBox.Text = SlickUpload1.MaxFiles.ToString()
        validExtensionsTextBox.Text = SlickUpload1.ValidExtensions
        invalidExtensionMessageTextBox.Text = SlickUpload1.InvalidExtensionMessage

        requiredFilesValidator.Enabled = requireFileCheckBox.Checked

        extensionValidator.Text = validationSummaryMessageTextBox.Text
        extensionValidator.Enabled = Not String.IsNullOrEmpty(validExtensionsTextBox.Text) AndAlso Not String.IsNullOrEmpty(validationSummaryMessageTextBox.Text)

        maxFilesSpan.InnerText = SlickUpload1.MaxFiles.ToString()
        requireFileSpan.InnerText = IIf(requireFileCheckBox.Checked, "Yes", "No")
        confirmNavigateSpan.InnerText = SlickUpload1.ConfirmNavigateDuringUploadMessage
        validExtensionsSpan.InnerText = SlickUpload1.ValidExtensions
        invalidExtensionMessageSpan.InnerText = SlickUpload1.InvalidExtensionMessage
        validationSummaryMessageSpan.InnerText = validationSummaryMessageTextBox.Text

        Dim onSave As String = "kw.get('" + SlickUpload1.ClientID + "').clear();Page_BlockSubmit=false;"

        saveSettingsButton.OnClientClick = onSave
        cancelSettingsButton.OnClientClick = onSave
    End Sub

    Protected Sub SlickUpload1_UploadComplete(ByVal sender As Object, ByVal e As UploadStatusEventArgs) Handles SlickUpload1.UploadComplete
        uploadPanel.Visible = False
        resultPanel.Visible = True

        If Not e.UploadedFiles Is Nothing AndAlso e.UploadedFiles.Count > 0 Then
            resultsRepeater.DataSource = e.UploadedFiles
            resultsRepeater.DataBind()

            resultsRepeater.Visible = True
        Else
            resultsRepeater.Visible = False
        End If
    End Sub

    Protected Sub newUploadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newUploadButton.Click
        uploadPanel.Visible = True
        resultPanel.Visible = False
    End Sub

    Protected Sub saveSettingsButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveSettingsButton.Click
        Dim maxFiles As Integer

        If Not Integer.TryParse(maxFilesTextBox.Text, maxFiles) Then
            maxFiles = -1
        End If

        SlickUpload1.MaxFiles = maxFiles
        SlickUpload1.ConfirmNavigateDuringUploadMessage = confirmNavigateTextBox.Text
        SlickUpload1.ValidExtensions = validExtensionsTextBox.Text
        SlickUpload1.InvalidExtensionMessage = invalidExtensionMessageTextBox.Text
    End Sub
End Class
