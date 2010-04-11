<%@ Control Language="c#" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<script language="C#" runat="server">
	string _title;

	public string Title
	{
		get
		{
			return _title;
		}
		set
		{
			_title = value;
		}
	}
</script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title><%= Title %> <%= Title.IndexOf(" - SlickUpload Samples") == -1 ? " - SlickUpload Samples" : "" %></title>
    <style type="text/css">
        * {font-family:Calibri, Verdana, Sans-Serif}
        h1, h2, h3 {font-weight:normal}
        a {text-decoration:none}
        a:hover {text-decoration:underline}
        a img {border:0}
        table.results {border-collapse:collapse;border:1px solid #c0c0c0;}
        table.results td, table.results th {border:1px solid #c0c0c0}
        table.results th {background-color:#e0e0e0}
        table.settings {width:99%}
        table.settings th {text-align:left;font-weight:normal}
        table.settings td {height:1.5em}
        blockquote {border:dotted 1px #c0c0c0;background-color:#f8f8f8;margin:1em;padding:.5em 1em .5em 1em}
        code, code span {font-family:Consolas, Courier New, monospace}
        
        #headerContainer {border-bottom:dotted 2px #ccc;margin-bottom:1em;}
        #header {width:40em;margin-left:auto;margin-right:auto}
        #sidebar {float:left;width:14em;margin-right:1em;margin-bottom:1em;padding:.5em;background-color:#f0f0f0;border:2px dotted #888;}
        #sidebar p {font-size:90%}
        #content {margin-left:15em;padding-left:1em}
        #footer {text-align:center;margin-top:1em;padding-top:.5em;border-top:dotted 2px #ccc;color:#888;clear:both}
    </style>
</head>
<body>
        <div id="headerContainer">
            <div id="header">
                <a href="http://krystalware.com/Products/SlickUpload/"><img width="125" height="29" src="<%=ResolveUrl("~/Common/krystalware_small.png") %>" style="float:right" /></a>
                <h2 style="clear:none">
                    <img width="48" height="48" src="<%=ResolveUrl("~/Common/SlickUpload_48x48.png") %>" style="vertical-align:middle;margin-right:.5em" />
                    SlickUpload Samples
                </h2>
            </div>
        </div>
        <div id="sidebar">
            <h2 style="margin:0;padding:0">Available Samples</h2>
            <p><strong><a href="<%=ResolveUrl("~/Overview/Default.aspx") %>">Overview</a></strong> &ndash; demonstrates the basics of SlickUpload. Selecting files, maximum file limit, file type validation, require files to be selected.</p>
            <p><strong><a href="<%=ResolveUrl("~/FileNameGenerator/Default.aspx") %>">FileNameGenerator</a></strong> &ndash; how to control and generate server filenames for files as they are uploaded.</p>
            <p><strong><a href="<%=ResolveUrl("~/AdditionalFields/Default.aspx") %>">Additional Fields</a></strong> &ndash; how to add additional input fields for each selected file.</p>
            <p><strong><a href="<%=ResolveUrl("~/CustomProgress/Default.aspx") %>">Custom Progress</a></strong> &ndash; display custom progress information during a postprocessing step after files are uploaded.</p>
            <p><strong><a href="<%=ResolveUrl("~/SqlClient/Default.aspx") %>">Upload to SQL Server</a></strong> &ndash; upload directly to a SQL Server, streaming with no memory usage.</p>
            <p><strong><a href="<%=ResolveUrl("~/CustomUploadStreamProvider/Default.aspx") %>">Custom UploadStreamProvider</a></strong> &ndash; how to develop your own upload stream provider &ndash; this example shows how to zip files as they are uploaded.</p>
            <p><strong><a href="<%=ResolveUrl("~/Simple/Default.aspx") %>">Simple</a></strong> &ndash; the bare metal SlickUpload control, drag-dropped onto the page.</p>
            <h2 style="margin-bottom:0;padding-bottom:0">Other Resources</h2>
            <p><strong><a href="http://krystalware.com/Products/SlickUpload/Documentation/">Documentation</a></strong> &ndash; Read the SlickUpload documentation.</p>
            <p style="margin-bottom:0"><strong><a href="http://krystalware.com/forums/">Forums</a></strong> &ndash; Ask or answer questions in the SlickUpload support forum.</p>
        </div>
        <div id="content">
            <h1><%= Title %> Sample</h1>