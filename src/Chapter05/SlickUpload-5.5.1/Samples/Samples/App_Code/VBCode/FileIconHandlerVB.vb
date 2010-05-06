Imports Microsoft.VisualBasic
Imports System.IO

Public Class FileIconHandlerVB
    Implements IHttpHandler

    Public ReadOnly Property IsReusable() As Boolean Implements System.Web.IHttpHandler.IsReusable
        Get
            Return True
        End Get
    End Property

    Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
        Dim ext As String = IIf(context.Request.QueryString("ext") Is Nothing, "xxx", context.Request.QueryString("ext"))

        Dim fileName As String = context.Server.MapPath("~/Common/icons/" + ext + ".gif")

        If Not File.Exists(fileName) Then
            fileName = context.Server.MapPath("~/Common/icons/xxx.gif")
        End If

        context.Response.ContentType = "image/gif"
        context.Response.TransmitFile(fileName)
    End Sub
End Class
