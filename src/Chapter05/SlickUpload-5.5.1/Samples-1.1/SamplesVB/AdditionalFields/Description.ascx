<%@ Control Language="C#" %>
<%@ Register Assembly="Krystalware.SourceFormatter" Namespace="Krystalware.SourceFormatter"
    TagPrefix="kw" %>
<style type="text/css">
	<%= Krystalware.SourceFormatter.Source.SourceCss %>
</style>
<p>This sample demonstrates how to add additional form elements for each file, and then read out the values that are entered. To add form elements, simply add any form element (input, select, etc.) to the &lt;FileTemplate&gt; template.
   Give them a unique name (this is how you will read them back after an upload). For this example, the template is as follows:
</p>
<kw:Source Type="Html" runat="server">
<kw:FileListRemoveLink runatserver Title="Remove">
    [x]
</kw:FileListRemoveLink>
<kw:FileListFileName runatserver />
<kw:FileListValidationMessage runatserver ForeColor="Red" />
<br />
Name: <input type="text" name="name" />
Category:
<select name="category">
    <option value="Public">Public</option>
    <option value="Private">Private</option>
    <option value="All">All</option>
</select>
<br />
Description:<br />
<textarea name="description" rows="5" cols="50"></textarea>
</kw:Source>
<p>Notice the additional input elements at the end of the template. This adds three additional elements to each file item:</p>
<ul>
    <li>An &lt;input&gt; named "name"</li>
    <li>An &lt;select&gt; named "category"</li>
    <li>A &lt;textarea&gt; named "description"</li>
</ul>
<p>
    SlickUpload takes care of templating and managing the names for each element as the files are selected and uploaded. After an upload, you can access the values that were posted
    for each file via the UploadedFile.FormValues dictionary. So, for this example, given an UploadedFile named "file", you could write the following code in the UploadComplete event
    to read back the form values that were posted for that file:
</p>
<kw:Source Type="VB" runat="server" ID="Source1">
    Dim name As String = file.FormValues("name")
    Dim category As String = file.FormValues("category")
    Dim description As String = file.FormValues("description")
</kw:Source>
