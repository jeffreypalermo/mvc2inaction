<%@ Control Language="C#" %>
<%@ Register Assembly="Krystalware.SourceFormatter" Namespace="Krystalware.SourceFormatter"
    TagPrefix="kw" %>
<style type="text/css">
	<%= Krystalware.SourceFormatter.Source.SourceCss %>
</style>
<p>This is the overview sample, which demonstrates the basics of SlickUpload. The following concepts are covered in this sample:</p>
<h2>Selecting files</h2>
<p>
    The SlickUpload control is used to allow file selection. Files can be selected, removed, and uploaded. The SlickUpload control is fully templatable allowing customization of look and feel. This sample
    uses the bare metal SlickUpload skin.
</p>
<h2>Maximum file limit</h2>
<p>
    The SlickUpload control has the capability to limit the number of files selected. By default, unlimited files are allowed, but by setting the MaxFiles property of the SlickUpload control, you can limit
    to any specific number. For example, to limit to three (3) files, you would set the MaxFiles property as follows:        
</p>
<kw:Source ID="Source1" Type="Html" runat="server"><kw:SlickUpload ... MaxFiles="3" ... /></kw:Source>
<h2>Require file selection</h2>
<p>
    SlickUpload provides a rich client side object model that allows you to easily hook in and do validation checks. For this example, an ASP.NET CustomValidator is used, but you could easily replace
    this with whatever validation framework you use. The validation javascript looks like this:
</p>
<kw:Source ID="Source2" Type="JavaScript" runat="server">
function Validate_SlickUploadRequiredFiles(source, args)
{
    args.IsValid = (kw.get("<serverblockstart=SlickUpload1.ClientID %>").get_Files().length > 0);
}        
</kw:Source>
<p>This validation function gets a reference to the SlickUpload control on the page, gets a list of the files currently selected, and checks its length to ensure at least one file has been selected.
   To hook this into the ASP.NET validation framework, you can use a CustomValidator configured as follows:
</p>
<kw:Source ID="Source3" Type="Html" runat="server"><asp:CustomValidator runatserver ClientValidationFunction="Validate_SlickUploadRequiredFiles" Text="Please select at least one file to upload." /></kw:Source>
<h2>Extension validation</h2>
<p>
    The SlickUpload control has built in file extension validation. By default, all extensions are allowed. To turn on validation, set the ValidExtensions property of the SlickUpload control to a comma seperated list of extensions that are considered valid. For example, to allow images
    only, you might use a setting such as:
</p>
<kw:Source ID="Source4" Type="Html" runat="server"><kw:SlickUpload ... ValidExtensions=".png,.gif,.jpg" ... /></kw:Source>
<p>To set a validation message to be displayed next to each invalid file, set the InvalidExtensionMessage property of the SlickUpload control. For example:
<kw:Source ID="Source5" Type="Html" runat="server"><kw:SlickUpload ... InvalidExtensionMessage="Please select an image (*.png, *.gif, *.jpg)." ... /></kw:Source>
<p>You can also implement a seperate validator to display an additional message, or if you want a per page message instead of per file. To do this, use a validation javascript such as:</p>
<kw:Source ID="Source6" Type="JavaScript" runat="server">
function Validate_SlickUploadValidExtensions(source, args)
{
    var files = kw.get("<serverblockstart=SlickUpload1.ClientID %>").get_Files();

    args.IsValid = true;

    for (var i = 0; i < files.length; i++)
    {
        if (!files[i].isValidExtension)
        {
            args.IsValid = false;

            return;
        }
    }
}
</kw:Source>
<p>This javascript is similar to the required file validation. It gets a reference to the SlickUpload control, gets a list of the files currently selected, and then iterates through the list to
   determine if any invalid files have been selected. To hook this into the ASP.NET validation framework, you can use a CustomValidator configured as follows:
</p>
<kw:Source ID="Source7" Type="Html" runat="server"><asp:CustomValidator runatserver ClientValidationFunction="Validate_SlickUploadValidExtensions" Text="Please select an image (*.png, *.gif, *.jpg)." /></kw:Source>
