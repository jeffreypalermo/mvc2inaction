<%@ Control Language="C#" %>
<p>Not only can you use the built in File and SqlClient UploadStreamProviders, you can also create your own custom provider that returns a stream for SlickUpload to write files to. This
   allows you to do any stream transformations on the file &ndash; checksum, encrypt, etc.
</p>
<p>This sample demonstrates an UploadStreamProvider that zips all files as they are uploaded. The configuration is as follows:</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
    <kw:Source Type="Html" runat="server"><uploadStreamProvider provider="Custom" location="~/CustomUploadStreamProvider/Files/" type="ZipUploadStreamProviderCS, App_SubCode_CSCode" /></kw:Source>
<% } else { %>          
    <kw:Source Type="Html" runat="server"><uploadStreamProvider provider="Custom" location="~/CustomUploadStreamProvider/Files/" type="ZipUploadStreamProviderVB, App_SubCode_VBCode" /></kw:Source>
<% } %>
<p>The heart of the UploadStreamProvider is the GetOutputStream method. SlickUpload calls this method for each file that is uploaded to get a stream to which to write the file. In this case,
   we create and return a zip stream:</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source Type="CSharp" runat="server">
    public Stream GetOutputStream(UploadedFile file)
    {
        FileStream fileS = null;
        ZipOutputStream zipS = null;

        try
        {
            string outputPath = GetZipPath(file);

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            fileS = File.OpenWrite(outputPath);
            zipS = new ZipOutputStream(fileS);

            zipS.SetLevel(5);

            zipS.PutNextEntry(new ZipEntry(file.ClientName));

            file.LocationInfo[FileNameKey] = outputPath;

            return zipS;
        }
        catch
        {
            if (fileS != null)
                fileS.Dispose();

            if (zipS != null)
                zipS.Dispose();

            return null;
        }
    }
</kw:Source>
<% } else { %>          
<kw:Source Type="VB" runat="server">
    Public Function GetOutputStream(ByVal f As UploadedFile) As Stream Implements IUploadStreamProvider.GetOutputStream
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
                fileS.Dispose()
            End If

            If Not zipS Is Nothing Then
                zipS.Dispose()
            End If

            Return Nothing
        End Try
    End Function
</kw:Source>
<% } %>
<p>The GetInputStream is a mirror image of this method &ndash; it returns a stream with the contents of the file. This isn't required to be implemented
   if your code accesses the file data some other way, so you may throw a NotImplementedException from this method.</p>
<p>The RemoveOutput is the last method in the UploadStreamProvider and should remove anything created by the stream returned from the GetOutputStream
   method. It will be called if the upload fails or errors and needs to be cleaned up.</p>