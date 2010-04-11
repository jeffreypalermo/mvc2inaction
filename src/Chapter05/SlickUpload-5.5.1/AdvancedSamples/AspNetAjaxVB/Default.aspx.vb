Imports Krystalware.SlickUpload.Controls

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub updateButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles updateButton.Click
        updateLabel.Text = DateTime.Now.ToLongTimeString()
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
End Class