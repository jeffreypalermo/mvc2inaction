Imports System.IO

Imports Krystalware.SlickUpload
Imports Krystalware.SlickUpload.Providers

Namespace FileNameGenerator
    ''' <summary>
    ''' An <see cref="IFileNameGenerator" /> that puts each file into a folder named for the first character
    ''' in the file naMyBase.
    ''' </summary>
    Public Class PrefixFolderFileNameGenerator
        Implements IFileNameGenerator

        Public Function GenerateFileName(ByVal file As Krystalware.SlickUpload.UploadedFile) As String Implements Krystalware.SlickUpload.Providers.IFileNameGenerator.GenerateFileName
            Return Path.Combine(file.ClientName.Substring(0, 1), file.ClientName)
        End Function
    End Class
End Namespace