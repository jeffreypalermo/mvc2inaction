Imports Krystalware.SlickUpload.Controls
Imports Krystalware.SlickUpload.Configuration
Imports Krystalware.SlickUpload.Status

Partial Class Clustered_DefaultVB
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        SlickUpload1.HideDuringUploadElements = "fileSelectText," + uploadButton.ClientID

        ''REMOVE FOR APPLICATION CODE
        'Only for sample, to catch exception if the sql connection isn't properly specified.
        Try
            Dim sm As SqlClientStatusManager = New SqlClientStatusManager(SlickUploadConfiguration.StatusManager)

            sm.RemoveStaleStatus(1000)

            SlickUpload1.Visible = True
            uploadButton.Visible = True

            errorMessage.Visible = False
        Catch ex As Exception
            SlickUpload1.Visible = False
            uploadButton.Visible = False

            errorMessage.InnerHtml += ex.GetType().FullName + ": " + ex.Message
            errorMessage.Visible = True
        End Try
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
End Class
