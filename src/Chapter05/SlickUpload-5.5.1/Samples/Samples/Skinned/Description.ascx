<%@ Control Language="C#" %>
<p>The SlickUpload control is fully templatable, giving detailed control over how it looks and acts. This example demonstrates two simple templates &ndash;
   templating the file list and using an image for the progress bar. You can manipulate any other part of the control by modifying the default template HTML and/or adding CSS.
</p>
<h2>Templating the file list</h2>
<p>The file list item is controlled by the <code>&lt;FileTemplate&gt;</code> template. In this example, we do a couple things to spiff up the
   layout from the standard layout:
</p>
<h3>Create a border around each item</h3>
<kw:Source runat="server" Type="Html">
<div style="border:solid 1px #ccc;margin:1em;padding:1em">
</kw:Source>
<h3>Float the remove link to the top right and add an image</h3>
<kw:Source runat="server" Type="Html">
<kw:FileListRemoveLink runatserver Title="Remove" style="float:right;margin-top:-.5em;margin-right:-.5em">
    <img width="20" height="20" style="vertical-align:middle" src="<serverblockstart=ResolveUrl("~/Common/delete.png") %>" /> remove
</kw:FileListRemoveLink>
</kw:Source>
<h3>Add a file extension icon</h3>
<kw:Source runat="server" Type="Html">
<img id="extImage" width="32" height="32" style="vertical-align:middle;" />
</kw:Source>
<p>This last feature, a file extension icon, takes a little more to hook up than just the HTML. The HTML provides a placeholder for
   the image. We then hook up an event that fires after each file is added:</p>
<kw:Source runat="server" Type="Html">
<kw:SlickUpload ... OnClientFileAdded="fileAdded" ... />
</kw:Source>
<p>The event handler gets a reference to the img tag and sets the image source URL based on the file extension:</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source runat="server" Type="JavaScript">
function fileAdded(file)
{
    var extImage = file.getElementById("extImage");
    
    extImage.src = "FileIconCS.ashx?ext=" + file.extension;
}
</kw:Source>
<% } else { %>          
<kw:Source runat="server" Type="JavaScript">
function fileAdded(file)
{
    var extImage = file.getElementById("extImage");
    
    extImage.src = "FileIconVB.ashx?ext=" + file.extension;
}
</kw:Source>
<% } %>
<p>This sets the source to a simple handler which pulls the proper icon. For this example, there is a folder of icons located at ~/Common/icons.
   The handler selects the proper icon based on file extension and returns it to the client:
</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source runat="server" Type="CSharp">
public void ProcessRequest(HttpContext context)
{
    string ext = context.Request.QueryString["ext"] ?? "xxx";

    string fileName = context.Server.MapPath("~/Common/icons/" + ext + ".gif");

    if (!File.Exists(fileName))
        fileName = context.Server.MapPath("~/Common/icons/xxx.gif");

    context.Response.ContentType = "image/gif";
    context.Response.TransmitFile(fileName);
}
</kw:Source>
<% } else { %>          
<kw:Source runat="server" Type="VB">
Public Sub ProcessRequest(ByVal context As System.Web.HttpContext) Implements System.Web.IHttpHandler.ProcessRequest
    Dim ext As String = IIf(context.Request.QueryString("ext") Is Nothing, "xxx", context.Request.QueryString("ext"))

    Dim fileName As String = context.Server.MapPath("~/Common/icons/" + ext + ".gif")

    If Not File.Exists(fileName) Then
        fileName = context.Server.MapPath("~/Common/icons/xxx.gif")
    End If

    context.Response.ContentType = "image/gif"
    context.Response.TransmitFile(fileName)
End Sub
</kw:Source>
<% } %>
<h2>Progress bar image</h2>
<p>
    To add a progress bar image is as simple as adding a background image to the <code>&lt;kw:UploadProgressBarElement&gt;</code>. This element renders into a div with a width based on the progress complete.
    To specify a progress image, simply add CSS that references your desired image:
</p>
<kw:Source runat="server" Type="Html">
<kw:UploadProgressBarElement ... style="background-image: url('xp.gif')..." ... />
</kw:Source>