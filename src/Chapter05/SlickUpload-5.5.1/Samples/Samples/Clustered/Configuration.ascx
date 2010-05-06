<%@ Control Language="C#" %>
<h1>Configuration</h1>
<p>Configuration for the status manager sample involves creating the status database and table and configuring SlickUpload
   to point at that database. To do this, perform the following steps:</p>
<ol>
    <li>Create a new database, or select an existing database to use</li>
    <li>Open and run the UploadStatusTable.sql script in the SlickUpload distribution package root folder on the selected database</li>
    <li>Uncomment the statusManager section in the root web.config. This section is only valid at the root of an application.</li>
    <li>Change the connection string in the statusManager web.config section to point to the database selected above</li>
</ol>
