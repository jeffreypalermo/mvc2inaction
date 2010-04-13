Imports Krystalware.SlickUpload.Controls

Partial Class Localization_DefaultVB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        SlickUpload1.HideDuringUploadElements = "fileSelectText," + uploadButton.ClientID
    End Sub

    Protected Sub newUploadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newUploadButton.Click
        uploadPanel.Visible = True
        resultPanel.Visible = False
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

    Protected Overrides Sub InitializeCulture()
        UICulture = IIf(Request.Form("ctl00$content$cultureDropDownList") Is Nothing, "auto", Request.Form("ctl00$content$cultureDropDownList"))

        MyBase.InitializeCulture()
    End Sub
End Class
