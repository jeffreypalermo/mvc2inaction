Imports Microsoft.VisualBasic

Imports Krystalware.SlickUpload.Controls
Imports Krystalware.SlickUpload.Status

Public Class _Default
    Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

    'This call is required by the Web Form Designer.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

    End Sub
    Protected WithEvents SlickUpload1 As Krystalware.SlickUpload.Controls.SlickUpload
    Protected WithEvents Button1 As System.Web.UI.WebControls.Button
    Protected WithEvents cancelButton As System.Web.UI.WebControls.Button
    Protected WithEvents uploadResult As System.Web.UI.WebControls.Label
    Protected WithEvents uploadFileList As System.Web.UI.WebControls.Repeater

    'NOTE: The following placeholder declaration is required by the Web Form Designer.
    'Do not delete or move it.
    Private designerPlaceholderDeclaration As System.Object

    Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
        'CODEGEN: This method call is required by the Web Form Designer
        'Do not modify it using the code editor.
        InitializeComponent()
    End Sub
#End Region

    Protected Sub SlickUpload1_UploadComplete(ByVal sender As Object, ByVal e As UploadStatusEventArgs) Handles SlickUpload1.UploadComplete
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
