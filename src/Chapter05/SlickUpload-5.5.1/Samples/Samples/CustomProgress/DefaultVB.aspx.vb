Imports System.Collections.Generic
Imports Krystalware.SlickUpload.Controls

Partial Class CustomProgress_DefaultVB
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
            'Simulate post processing
            Dim status As Dictionary(Of String, String) = New Dictionary(Of String, String)

            For i As Integer = 0 To 100
                status("percentComplete") = i.ToString()
                status("percentCompleteText") = i.ToString() + "%"

                'Update the progress context
                e.Status.UpdatePostProcessStatus(status)

                System.Threading.Thread.Sleep(100)
            Next i

            status("percentComplete") = "100"
            status("percentCompleteText") = "100 %"

            'Update the progress context as complete
            e.Status.UpdatePostProcessStatus(status, True)

            resultsRepeater.DataSource = e.UploadedFiles
            resultsRepeater.DataBind()

            resultsRepeater.Visible = True
        Else
            resultsRepeater.Visible = False
        End If
    End Sub
End Class
