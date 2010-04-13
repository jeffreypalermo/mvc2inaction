<%@ Control Language="C#" %>
<p>SlickUpload supports a postprocessing step so you can display progress as you process files. For example, processing/resizing images, uploading to S3, etc.
   To enable this, set the HasPostProcessStep="true" attribute on the SlickUpload control:
</p>
<kw:Source Type="Html" runat="server"><kw:SlickUpload ... HasPostProcessStep="true" ... /></kw:Source>
<p>To update SlickUpload with the current progress of your post processing step, handle the UploadComplete event and from within it, call the UploadStatus.UpdatePostProcessStatus method and pass in a dictionary of key/value pairs.
   These values are passed down to the client and displayed in the progress area. You can override the built in elements using their keys, or pass down your own
   status information. The sample post process step looks like this:
</p>
<% if (Request.Path.EndsWith("cs.aspx", StringComparison.InvariantCultureIgnoreCase)) { %>
<kw:Source Type="CSharp" runat="server">
// Simulate post processing
Dictionary<string, string> status = new Dictionary<string, string>();

for (int i = 0; i < 100; i++)
{
    status["percentComplete"] = i.ToString();
    status["percentCompleteText"] = i.ToString() + "%";

    // Update the progress context
    e.Status.UpdatePostProcessStatus(status);

    System.Threading.Thread.Sleep(100);
}

status["percentComplete"] = "100";
status["percentCompleteText"] = "100 %";

// Update the progress context as complete
e.Status.UpdatePostProcessStatus(status, true);
</kw:Source>
<% } else { %>          
<kw:Source Type="VB" runat="server">
'Simulate post processing
Dim status As Dictionary(Of String, String) = New Dictionary(Of String, String)

For i As Integer = 0 To 100
    status("percentComplete") = i.ToString()
    status("percentCompleteText") = i.ToString() + "%"

    'Update the progress context
    e.Status.UpdatePostProcessStatus(status)

    System.Threading.Thread.Sleep(100)
Next i

status("percentComplete") = "100"
status("percentCompleteText") = "100 %"

'Update the progress context as complete
e.Status.UpdatePostProcessStatus(status, True)
</kw:Source>
<% } %>
<p>
    Lets take this apart piece by piece. First, we create a dictionary to hold the values passed down to the client. In this case, we're doing a simple loop from 0 to 100 (representing the percent done),
    with a 100 millisecond delay between each progress update. The delay represents the work you would actually do during the post processing step. Each time through the loop,
    we set the percentComplete and percentCompleteText elements of the dictionary. Then we call the UpdatePostProcessStatus method, passing in the dictionary. This signals to SlickUpload that there are
    new values to display on the client, and they will be returned on the next update interval. When the post processing is complete, we do a final update and pass an additional argument of true,
    signalling that post processing is complete.
</p>
<p>
    To display the progress, add &lt;kw:ProgressElement&gt; and &lt;kw:ProgressBarElement&gt; controls to your page. Set the ElementKey of the control to the same value that was set in the dictionary.
    For our sample, the client template looks like this:    
</p>
<kw:Source Type="Html" runat="server">
<div style="border: 1px solid #008800; height: 1.5em; position: relative">
    <kw:ProgressBarElement runatserver Style="background-color: #00ee00; width: 0; height: 1.5em" ElementKey="percentComplete" />
    <div style="text-align: center; position: absolute; top: .15em; width: 100%">
        <kw:ProgressElement runatserver ElementKey="percentCompleteText">(calculating)</kw:ProgressElement>
    </div>
</div>
</kw:Source>
<p>Notice the ElementKey="percentComplete" and ElementKey="percentCompleteText" properties. This sets up these progress elements to read from the values we set in the UploadComplete event.</p>
<p>For this sample, we also add a little javascript magic to hide the upload progress bar and show the postprocessing section when postprocessing starts. This isn't necessary, but adds a nice flair:</p>
<kw:Source Type="JavaScript" runat="server">
function SlickUpload_OnClientProgressUpdate(data)
{
    var postProcessProgress = document.getElementById("postProcessProgress");

    // if we're postprocessing now, show the postprocessing progress section
    if (postProcessProgress.style.display == "none" && data.state == "PostProcessing")
    {
        var fileSelectText = document.getElementById("fileSelectText");
        var uploadProgress = document.getElementById("uploadProgress");

        fileSelectText.style.display = uploadProgress.style.display = "none";
        postProcessProgress.style.display = "";
    }
}
</kw:Source>
<p>The javascript function is hooked up to the SlickUpload control via the OnClientProgressUpdate property. This registers it to be called for each client side progress update:</p>
<kw:Source Type="Html" runat="server"><kw:SlickUpload ... OnClientProgressUpdate="SlickUpload_OnClientProgressUpdate" ... /></kw:Source>