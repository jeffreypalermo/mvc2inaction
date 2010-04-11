<%@ Control Language="C#" %>
<p>In clustered environments with multiple boxes or application instances, an upload may be handled by one instance with the progress requests being handled by another instance and
   the final postback by yet another instance. To handle this environment, SlickUpload includes a status management architecture for centralizing the upload status information.
   By default, the upload status is stored in application state (via the ApplicationStateStatusManager). SlickUpload includes a SqlClientStatusManager that stores the upload status
   in a central SQL Server database, as well as the capability to extend to use a custom status manager.
</p>
<p>
   This sample covers the configuration and use of the SQL Server status manager. To use this instead of the default ApplicationStateStatusManager, use a statusManager web.config
   configuration section like the following:
</p>
<kw:Source ID="Source1" Type="Html" runat="server">
<statusManager manager="SqlClient"
    connectionString="server=.;uid=xxx;pwd=xxx;database=xxx;"
    table="UploadStatus" keyField="UploadId" statusField="UploadStatus" lastUpdatedField="LastUpdated"
    updateInterval="1" />
</kw:Source>
<p>You can use other table and field names by changing them in the database and setting them in the SlickUpload configuration. This configuration is the default,
   built around the provided UploadStatusTable.sql schema.</p>
<p><em>NOTE: when looking at the status table during uploads in this sample, you may see extra orphan status records. This is because the sample architecture causes
    page postbacks to be handled as uploads. In a production application where uploads are directed only to the specified SlickUpload handler, orphan records won't be created.
    SlickUpload also includes an abandoned upload sweeper that eliminates orphaned status records every 10 minutes.</em>
</p>
