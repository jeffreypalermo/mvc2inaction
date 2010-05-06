Imports Krystalware.SlickUpload.controls

Namespace Simple
    Public Class _Default
        Inherits System.Web.UI.Page

#Region " Web Form Designer Generated Code "

        'This call is required by the Web Form Designer.
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()

        End Sub
        Protected WithEvents SlickUpload1 As Krystalware.SlickUpload.Controls.SlickUpload
        Protected WithEvents uploadButton As System.Web.UI.WebControls.Button
        Protected WithEvents resultsRepeater As System.Web.UI.WebControls.Repeater
        Protected WithEvents newUploadButton As System.Web.UI.WebControls.Button
        Protected WithEvents uploadPanel As System.Web.UI.HtmlControls.HtmlGenericControl
        Protected WithEvents resultPanel As System.Web.UI.HtmlControls.HtmlGenericControl

        'NOTE: The following placeholder declaration is required by the Web Form Designer.
        'Do not delete or move it.
        Private designerPlaceholderDeclaration As System.Object

        Private Sub Page_Init(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Init
            'CODEGEN: This method call is required by the Web Form Designer
            'Do not modify it using the code editor.
            InitializeComponent()
        End Sub

#End Region

        Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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
End Namespace