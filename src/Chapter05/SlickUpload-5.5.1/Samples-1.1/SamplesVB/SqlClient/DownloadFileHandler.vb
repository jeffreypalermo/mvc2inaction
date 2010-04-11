Imports System.Web
Imports Microsoft.VisualBasic
Imports System.IO

Namespace SqlClient
    Public Class DownloadFileHandler
        Implements IHttpHandler

        Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
            Get
                Return True
            End Get
        End Property

        Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
            Dim id As Integer = Integer.Parse(context.Request.QueryString("id"))

            Dim file As RepositoryFile = RepositoryFile.GetById(id)

            context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name)
            context.Response.AddHeader("Content-Length", file.Length.ToString())
            context.Response.ContentType = "application/octet-stream"

            Dim dataStream As Stream
            Try
                dataStream = file.GetDataStream()

                Dim buffer As Byte() = New Byte(8192) {}

                Dim read As Integer

                Do
                    read = dataStream.Read(buffer, 0, 8192)

                    If read > 0 Then
                        context.Response.OutputStream.Write(buffer, 0, read)
                    End If
                Loop While read > 0
            Finally
                If Not dataStream Is Nothing Then
                    dataStream.Close()
                End If
            End Try
        End Sub
    End Class
End Namespace