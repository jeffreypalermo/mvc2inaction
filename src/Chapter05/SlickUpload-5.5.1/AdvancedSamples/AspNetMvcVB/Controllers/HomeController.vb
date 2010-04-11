Imports Krystalware.SlickUpload.Controls
Imports Krystalware.SlickUpload.Status

<HandleError()> _
Public Class HomeController
    Inherits System.Web.Mvc.Controller

    Function Index() As ActionResult
        ViewData("Message") = "Select files to upload"

        Return View()
    End Function

    Function UploadResult(ByVal status As UploadStatus) As ActionResult
        Return View(status)
    End Function
End Class
