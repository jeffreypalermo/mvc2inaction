<%@ Control Language="C#" %>
<%@ Register Assembly="Krystalware.SourceFormatter" Namespace="Krystalware.SourceFormatter"
    TagPrefix="kw" %>
<style type="text/css">
	<%= Krystalware.SourceFormatter.Source.SourceCss %>
</style>
<p>SlickUpload includes the capability to upload streaming directly to a SQL database, eliminating any in-memory copy of files as they are uploaded. This
   is accomplished by using the SqlClient UploadStreamProvider. To use this instead of the default File UploadStreamProvider, use an uploadStreamProvider web.config
   configuration section like the following:
</p>
<kw:Source Type="Html" runat="server">
<uploadStreamProvider provider="SqlClient"
    connectionString="server=.;uid=xxx;pwd=xxx;database=SlickUploadTest;"
    table="SlickUploadFile"
    keyField="FileId" dataField="Data" fileNameField="FileName" />
</kw:Source>
<p>You can use other table and field names by changing them in the database and setting them in the SlickUpload configuration. This configuration is the default,
   built around the provided SlickUploadFile.sql schema. Once the files are uploaded, you can update the records with additional info, select, manipulate, etc. just
   like any other database record.
</p>
<p>To retrieve the data from the record while still maintaining the streaming interaction, use the SqlClientOutputStream class. Create an instance and read the data out from the stream,
   manipulating it or sending it to the client as you go. For example, here's how it is used in this sample:
</p>
<kw:Source Type="CSharp" runat="server">
public Stream GetDataStream()
{
    return new SqlClientOutputStream(_cnString, _table, _dataField, _keyField, _id);
}
</kw:Source>
<p>The download file handler uses this method to get a stream, and then streams the file down to the client:</p>
<kw:Source Type="CSharp" runat="server">
public void ProcessRequest(HttpContext context)
{
    int id = int.Parse(context.Request.QueryString["id"]);

    RepositoryFile file = RepositoryFile.GetById(id);

    context.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
    context.Response.AddHeader("Content-Length", file.Length.ToString());
    context.Response.ContentType = "application/octet-stream";

    using (Stream dataStream = file.GetDataStream())
    {
        byte[] buffer = new byte[8192];

        int read;

        while ((read = dataStream.Read(buffer, 0, 8192)) > 0)
            context.Response.OutputStream.Write(buffer, 0, read);
    }
}
</kw:Source>