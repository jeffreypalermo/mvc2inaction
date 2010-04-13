Imports System.IO
Imports System.Web

Imports ICSharpCode.SharpZipLib.Zip

Imports Krystalware.SlickUpload
Imports Krystalware.SlickUpload.Providers
Imports Krystalware.SlickUpload.Configuration

Namespace CustomUploadStreamProvider
    ''' <summary>
    ''' An <see cref="IUploadStreamProvider" /> that streams each file into its own .zip file.
    ''' </summary>
    Public Class ZipUploadStreamProvider
        Inherits UploadStreamProviderBase

        ''' <summary>
        ''' The <see cref="UploadedFile.LocationInfo" /> key used to store the server filename value.
        ''' </summary>
        Public Shared ReadOnly FileNameKey As String = "fileName"

        Public Overrides Function GetInputStream(ByVal f As Krystalware.SlickUpload.UploadedFile) As System.IO.Stream
            Dim fileS As FileStream = Nothing
            Dim zipS As ZipInputStream = Nothing

            Try
                Dim path As String = GetZipPath(f)

                fileS = File.OpenRead(path)
                zipS = New ZipInputStream(fileS)

                zipS.GetNextEntry()

                Return zipS
            Catch
                If Not fileS Is Nothing Then
                    fileS.Close()
                End If

                If Not zipS Is Nothing Then
                    zipS.Close()
                End If

                Return Nothing
            End Try
        End Function

        Public Overrides Function GetOutputStream(ByVal f As Krystalware.SlickUpload.UploadedFile) As System.IO.Stream
            Dim fileS As FileStream = Nothing
            Dim zipS As ZipOutputStream = Nothing

            Try
                Dim outputPath As String = GetZipPath(f)

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath))

                fileS = File.OpenWrite(outputPath)
                zipS = New ZipOutputStream(fileS)

                zipS.SetLevel(5)

                zipS.PutNextEntry(New ZipEntry(f.ClientName))

                f.LocationInfo(FileNameKey) = outputPath

                Return zipS
            Catch
                If Not fileS Is Nothing Then
                    fileS.Close()
                End If

                If Not zipS Is Nothing Then
                    zipS.Close()
                End If

                Return Nothing
            End Try
        End Function

        Public Overrides Sub RemoveOutput(ByVal f As Krystalware.SlickUpload.UploadedFile)
            Dim path As String = GetZipPath(f)

            If File.Exists(path) Then
                File.Delete(path)
            End If
        End Sub

        Private Function GetZipPath(ByVal file As UploadedFile) As String
            Dim location As String = SlickUploadConfiguration.UploadStreamProvider("location")

            If location Is Nothing OrElse location.Length = 0 Then
                location = "~/Files/"
            End If

            Return Path.Combine(HttpContext.Current.Server.MapPath(location), Path.GetFileNameWithoutExtension(file.ClientName) + ".zip")
        End Function
    End Class
End Namespace