<%@ Control Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Import Namespace="Krystalware.SlickUpload.Configuration" %>
            <div style="border:1px solid #ccc;padding:.5em">
                <strong>NOTE:</strong> the maximum allowed request size for this sample is <%= (SlickUploadConfiguration.MaxRequestLength / 1024 / 1024).ToString() + " MB" %>. If you attempt to upload files larger than this,
                you will recieve a oversized upload error which SlickUpload will handle gracefully. This is controlled by the maxRequestLength attribute of the
                httpRuntime key in the web.config file.
            </div>
            <h1>Description</h1>            
