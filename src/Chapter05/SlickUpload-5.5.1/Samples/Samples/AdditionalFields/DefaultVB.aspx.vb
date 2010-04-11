Imports System.Collections.Generic
Imports System.Text
Imports Krystalware.SlickUpload.Controls

Partial Class AdditionalFields_DefaultVB
    Inherits System.Web.UI.Page

    Protected Function SerializeDictionaryToString(ByVal values As IDictionary(Of String, String)) As String
        Dim sb As StringBuilder = New StringBuilder()

        For Each pair As KeyValuePair(Of String, String) In values
            If sb.Length > 0 Then
                sb.Append("<br />")
            End If

            sb.Append(pair.Key)
            sb.Append(": ")
            sb.Append(pair.Value.Replace(vbNewLine, "<br />"))
        Next pair

        Return sb.ToString()
    End Function

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
End Class
