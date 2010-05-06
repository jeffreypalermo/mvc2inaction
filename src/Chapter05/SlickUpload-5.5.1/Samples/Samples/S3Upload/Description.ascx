<%@ Control Language="C#" %>
<script runat="server">
    protected string CurrentLanguageExtension
    {
        get
        {
            if (Request.Path.EndsWith("vb.aspx", StringComparison.InvariantCultureIgnoreCase))
                return "VB.aspx";
            else
                return "CS.aspx";
        }
    }
</script>
<p>This sample builds on the <a href="<%=ResolveUrl("~/CustomProgress/Default") + CurrentLanguageExtension %>">Custom Progress</a> sample and demonstrates how to upload to S3 with progress through the entire process &ndash; during the upload to the server as well as the upload to S3.
   It uses the excellent <a href="http://www.codeplex.com/ThreeSharp/" rel="nofollow">Affirma ThreeSharp library</a> to communicate with S3.
</p>
<p>First, we create a ThreeSharpConfig and ThreeSharpQuery based on the Amazon AccessKeyID and SecretAccessKey stored in the web.config.
   ThreeSharpQuery is the core of ThreeSharp and manages all other object interactions.</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source Type="CSharp" runat="server">
ThreeSharpConfig cfg = new ThreeSharpConfig();

cfg.AwsAccessKeyID = ConfigurationManager.AppSettings["awsAccessKeyId"];
cfg.AwsSecretAccessKey = ConfigurationManager.AppSettings["awsSecretAccessKey"];

_q = new ThreeSharpQuery(cfg);
</kw:Source>
<% } else { %>          
<kw:Source Type="VB" runat="server">
Dim cfg As ThreeSharpConfig = New ThreeSharpConfig()

cfg.AwsAccessKeyID = ConfigurationManager.AppSettings("awsAccessKeyId")
cfg.AwsSecretAccessKey = ConfigurationManager.AppSettings("awsSecretAccessKey")

_q = New ThreeSharpQuery(cfg)
</kw:Source>
<% } %>
<p>In the UploadComplete event, we do a little calculation and setup to get ready to upload:</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source Type="CSharp" runat="server">
Dictionary<string, string> status = new Dictionary<string, string>();

status["percentComplete"] = "0";
status["percentCompleteText"] = "0%";

// Update the progress context
e.Status.UpdatePostProcessStatus(status);

string bucket = ConfigurationManager.AppSettings["awsBucket"];

long totalLength = 0;
long transferredLength = 0;

// Calculate total length
foreach (UploadedFile uFile in e.UploadedFiles)
    totalLength += uFile.ContentLength;
</kw:Source>
<% } else { %>          
<kw:Source Type="VB" runat="server">
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
</kw:Source>
<% } %>
<p>Then, we get right down to business. For each file that was uploaded, we create an ObjectAddRequest to post it to S3. We load the request with the file to be sent, and then fire up a thread to do the actual sending:</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source Type="CSharp" runat="server">
// Upload each file
foreach (UploadedFile uFile in e.UploadedFiles)
{
    string fileName = uFile.LocationInfo[FileUploadStreamProvider.FileNameKey];

    using (ObjectAddRequest req = new ObjectAddRequest(bucket, Server.UrlEncode(uFile.ClientName)))
    {
        req.LoadStreamWithFile(fileName);

        // Create and fire up a new thread to do the actual upload
        Thread t = new Thread(UploadThread);

        t.Start(req);
</kw:Source>
<% } else { %>          
<kw:Source Type="VB" runat="server">
'Upload each file
For Each ufile As UploadedFile In e.UploadedFiles
    Dim fileName As String = ufile.LocationInfo(FileUploadStreamProvider.FileNameKey)

    Using req As ObjectAddRequest = New ObjectAddRequest(bucket, Server.UrlEncode(ufile.ClientName))
        req.LoadStreamWithFile(fileName)

        'Create and fire up a new thread to do the actual upload
        Dim t As Thread = New Thread(AddressOf UploadThread)

        t.Start(req)
</kw:Source>
<% } %>
<p>The thread is very simple. It executes the add request and waits for a response:</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source Type="CSharp" runat="server">
void UploadThread(object data)
{
    ObjectAddRequest req = (ObjectAddRequest)data;

    using (ObjectAddResponse resp = _q.ObjectAdd(req))
    { }
}
</kw:Source>
<% } else { %>          
<kw:Source Type="VB" runat="server">
Sub UploadThread(ByVal data As Object)
    Dim req As ObjectAddRequest = DirectCast(data, ObjectAddRequest)

    Using resp As ObjectAddResponse = _q.ObjectAdd(req)

    End Using
End Sub
</kw:Source>
<% } %>
<p>While the thread is doing the actual uploading to S3, we watch the progress and continuously update it to the client:</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source Type="CSharp" runat="server">
while (t.IsAlive && req.BytesTransferred < req.BytesTotal)
{
    float percentComplete = ((transferredLength + req.BytesTransferred) / (float)totalLength);

    status["percentComplete"] = (percentComplete * 100).ToString("f2");
    status["percentCompleteText"] = percentComplete.ToString("p2");

    // Update the progress context
    e.Status.UpdatePostProcessStatus(status);

    // wait 500ms
    Thread.Sleep(500);
}
</kw:Source>
<% } else { %>          
<kw:Source Type="VB" runat="server">
While t.IsAlive AndAlso req.BytesTransferred < req.BytesTotal
    Dim percentComplete As Single = ((transferredLength + req.BytesTransferred) / CType(totalLength, Single))

    status("percentComplete") = (percentComplete * 100).ToString("f2")
    status("percentCompleteText") = percentComplete.ToString("p2")

    'Update the progress context
    e.Status.UpdatePostProcessStatus(status)

    'wait 500ms
    Thread.Sleep(500)
End While
</kw:Source>
<% } %>
<p>Once the file is complete, we tally up the data that was sent and remove the local copy of the file:</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source Type="CSharp" runat="server">
transferredLength += uFile.ContentLength;

File.Delete(fileName);
</kw:Source>
<% } else { %>          
<kw:Source Type="VB" runat="server">
transferredLength += ufile.ContentLength

File.Delete(fileName)
</kw:Source>
<% } %>
<p>Finally, after all files are uploaded, we signal that postprocessing is complete:</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source Type="CSharp" runat="server">
status["percentComplete"] = "100";
status["percentCompleteText"] = "100 %";

// Update the progress context
e.Status.UpdatePostProcessStatus(status, true);
</kw:Source>
<% } else { %>          
<kw:Source Type="VB" runat="server">
status("percentComplete") = "100"
status("percentCompleteText") = "100 %"

'Update the progress context
e.Status.UpdatePostProcessStatus(status, True)
</kw:Source>
<% } %>