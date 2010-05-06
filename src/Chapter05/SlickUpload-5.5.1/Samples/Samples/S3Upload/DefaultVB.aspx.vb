Imports System.Collections.Generic
Imports Krystalware.SlickUpload.Controls
Imports Affirma.ThreeSharp.Query
Imports Affirma.ThreeSharp
Imports Krystalware.SlickUpload
Imports Krystalware.SlickUpload.Providers
Imports Affirma.ThreeSharp.Model
Imports System.Threading
Imports System.IO

Partial Class S3Upload_DefaultVB
    Inherits System.Web.UI.Page

    Private _q As ThreeSharpQuery
    Private _s3Exception As Exception

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        SlickUpload1.HideDuringUploadElements = "fileSelectText," + uploadButton.ClientID

        Dim cfg As ThreeSharpConfig = New ThreeSharpConfig()

        cfg.AwsAccessKeyID = ConfigurationManager.AppSettings("awsAccessKeyId")
        cfg.AwsSecretAccessKey = ConfigurationManager.AppSettings("awsSecretAccessKey")

        _q = New ThreeSharpQuery(cfg)
    End Sub

    Protected Sub newUploadButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newUploadButton.Click
        uploadPanel.Visible = True
        resultPanel.Visible = False
    End Sub

    Protected Sub SlickUpload1_UploadComplete(ByVal sender As Object, ByVal e As UploadStatusEventArgs) Handles SlickUpload1.UploadComplete
        uploadPanel.Visible = False
        resultPanel.Visible = True

        If Not e.UploadedFiles Is Nothing AndAlso e.UploadedFiles.Count > 0 Then
            Dim status As Dictionary(Of String, String) = New Dictionary(Of String, String)

            status("percentComplete") = "0"
            status("percentCompleteText") = "0%"

            'Update the progress context
            e.Status.UpdatePostProcessStatus(status)

            Dim bucket As String = ConfigurationManager.AppSettings("awsBucket")

            Dim totalLength As Long = 0
            Dim transferredLength As Long = 0

            'Calculate total length
            For Each uFile As UploadedFile In e.UploadedFiles
                totalLength += uFile.ContentLength
            Next uFile

            'Upload each file
            For Each ufile As UploadedFile In e.UploadedFiles
                Dim fileName As String = ufile.LocationInfo(FileUploadStreamProvider.FileNameKey)

                Using req As ObjectAddRequest = New ObjectAddRequest(bucket, Server.UrlEncode(ufile.ClientName))
                    req.LoadStreamWithFile(fileName)

                    'Create and fire up a new thread to do the actual upload
                    Dim t As Thread = New Thread(AddressOf UploadThread)

                    t.Start(req)

                    While t.IsAlive AndAlso req.BytesTransferred < req.BytesTotal
                        Dim percentComplete As Single = ((transferredLength + req.BytesTransferred) / CType(totalLength, Single))

                        status("percentComplete") = (percentComplete * 100).ToString("f2")
                        status("percentCompleteText") = percentComplete.ToString("p2")

                        'Update the progress context
                        e.Status.UpdatePostProcessStatus(status)

                        'wait 500ms
                        Thread.Sleep(500)
                    End While
                End Using

                transferredLength += ufile.ContentLength

                File.Delete(fileName)
            Next ufile

            status("percentComplete") = "100"
            status("percentCompleteText") = "100 %"

            'Update the progress context
            e.Status.UpdatePostProcessStatus(status, True)

            resultsRepeater.DataSource = e.UploadedFiles
            resultsRepeater.DataBind()

            resultsRepeater.Visible = True

            If Not _s3Exception Is Nothing Then
                errorMessage.InnerHtml += _s3Exception.GetType().FullName + ": " + _s3Exception.Message
                errorMessage.Visible = True
            End If
        Else
            resultsRepeater.Visible = False
        End If
    End Sub

    Sub UploadThread(ByVal data As Object)
        Try
            Dim req As ObjectAddRequest = DirectCast(data, ObjectAddRequest)

            Using resp As ObjectAddResponse = _q.ObjectAdd(req)

            End Using
        Catch ex As Exception
            _s3Exception = ex
        End Try
    End Sub
End Class
