Imports Krystalware.SlickUpload
Imports Krystalware.SlickUpload.Status

Partial Class _Default
    Inherits System.Web.UI.Page

    Protected Sub SlickUpload1_UploadComplete(ByVal sender As Object, ByVal e As Krystalware.SlickUpload.Controls.UploadStatusEventArgs) Handles SlickUpload1.UploadComplete
        uploadResult.Text = "Upload Result: " + e.Status.State.ToString()

        If e.Status.State = UploadState.Terminated Then
            uploadResult.Text += ". Reason: " + e.Status.Reason.ToString()
        End If

        If Not e.Status.State = UploadState.Terminated Then
            uploadFileList.DataSource = e.UploadedFiles
            uploadFileList.DataBind()
        End If

    End Sub
End Class
