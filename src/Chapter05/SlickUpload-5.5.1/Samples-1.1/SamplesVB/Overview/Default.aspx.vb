Imports Krystalware.SlickUpload.controls
Imports Microsoft.VisualBasic
Namespace Overview
    Public Class _Default
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents maxFilesTextBox As System.Web.UI.WebControls.TextBox
        Protected WithEvents requireFileCheckBox As System.Web.UI.WebControls.CheckBox
        Protected WithEvents validExtensionsTextBox As System.Web.UI.WebControls.TextBox
        Protected WithEvents invalidExtensionMessageTextBox As System.Web.UI.WebControls.TextBox
        Protected WithEvents validationSummaryMessageTextBox As System.Web.UI.WebControls.TextBox
        Protected WithEvents saveSettingsButton As System.Web.UI.WebControls.Button
        Protected WithEvents cancelSettingsButton As System.Web.UI.WebControls.Button
        Protected WithEvents SlickUpload1 As Krystalware.SlickUpload.Controls.SlickUpload
        Protected WithEvents requiredFilesValidator As System.Web.UI.WebControls.CustomValidator
        Protected WithEvents extensionValidator As System.Web.UI.WebControls.CustomValidator
        Protected WithEvents resultsRepeater As System.Web.UI.WebControls.Repeater
        Protected WithEvents newUploadButton As System.Web.UI.WebControls.Button
        Protected WithEvents settingsBox As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents maxFilesSpan As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents requireFileSpan As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents validExtensionsSpan As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents invalidExtensionMessageSpan As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents validationSummaryMessageSpan As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents uploadPanel As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents Div1 As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents resultPanel As System.Web.UI.HtmlControls.HtmlGenericControl

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Protected Sub Page_PreRender(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.PreRender
            settingsBox.Style("display") = IIf(uploadPanel.Visible, "block", "none")

            maxFilesTextBox.Text = SlickUpload1.MaxFiles.ToString()
            validExtensionsTextBox.Text = SlickUpload1.ValidExtensions
            invalidExtensionMessageTextBox.Text = SlickUpload1.InvalidExtensionMessage

            requiredFilesValidator.Enabled = requireFileCheckBox.Checked

            extensionValidator.Text = validationSummaryMessageTextBox.Text
            extensionValidator.Enabled = Not validExtensionsTextBox.Text Is Nothing AndAlso validExtensionsTextBox.Text.Length > 0 AndAlso _
              Not validationSummaryMessageTextBox.Text Is Nothing AndAlso validationSummaryMessageTextBox.Text.Length > 0

            maxFilesSpan.InnerText = SlickUpload1.MaxFiles.ToString()
            validExtensionsSpan.InnerText = SlickUpload1.ValidExtensions
            invalidExtensionMessageSpan.InnerText = SlickUpload1.InvalidExtensionMessage
            requireFileSpan.InnerText = IIf(requireFileCheckBox.Checked, "Yes", "No")
            validationSummaryMessageSpan.InnerText = validationSummaryMessageTextBox.Text

            saveSettingsButton.Attributes("onclick") = cancelSettingsButton.Attributes("onclick") = "kw.get('" + SlickUpload1.ClientID + "').clear();Page_BlockSubmit=false;"
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

            Try
                maxFiles = Integer.Parse(maxFilesTextBox.Text)
            Catch
                maxFiles = -1
            End Try

            SlickUpload1.MaxFiles = maxFiles
            SlickUpload1.ValidExtensions = validExtensionsTextBox.Text
            SlickUpload1.InvalidExtensionMessage = invalidExtensionMessageTextBox.Text
        End Sub
    End Class
End Namespace