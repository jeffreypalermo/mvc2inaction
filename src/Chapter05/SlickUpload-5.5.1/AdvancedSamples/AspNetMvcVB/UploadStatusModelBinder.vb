Imports Krystalware.SlickUpload
Imports Krystalware.SlickUpload.Controls
Imports Krystalware.SlickUpload.Status

Public Class UploadStatusModelBinder
    Implements IModelBinder

    Public Shared Sub Register(ByVal modelBinders As ModelBinderDictionary)
        If Not modelBinders.ContainsKey(GetType(UploadStatus)) Then
            modelBinders.Add(GetType(UploadStatus), New UploadStatusModelBinder())
        End If
    End Sub

    Public Function BindModel(ByVal controllerContext As System.Web.Mvc.ControllerContext, ByVal bindingContext As System.Web.Mvc.ModelBindingContext) As Object Implements System.Web.Mvc.IModelBinder.BindModel
        Dim status As UploadStatus = HttpUploadModule.GetUploadStatus()

        If status Is Nothing Then
            status = UploadConnector.GetUploadStatus()
        End If

        Return status
    End Function
End Class
