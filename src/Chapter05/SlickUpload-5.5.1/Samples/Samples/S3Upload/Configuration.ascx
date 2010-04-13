<%@ Control Language="C#" %>
<h1>Configuration</h1>
<p>Configuration for the S3 example involves configuring the appSettings in the web.config to point at the correct Amazon S3 account.
   To do this, perform the following steps:</p>
<ol>
    <li>Set the awsAccessKeyId element's value attribute to the Amazon S3 access key for your account</li>
    <li>Set the awsSecretAccessKey element's value attribute to the Amazon S3 secret key for your account</li>
    <li>Set the awsBucket element's value attribute to the name of an existing bucket to upload into. This sample will not create the bucket, so this must be an existing bucket your account can write to.</li>
</ol>
