<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register assembly="Krystalware.SlickUpload" namespace="Krystalware.SlickUpload.Controls" tagprefix="kw" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>SlickUpload Quick Start</title>
<script type="text/javascript">
    function cancelUpload() {
        kw.get("<%=SlickUpload1.ClientID %>").cancel();
    }     
</script>    
</head>
<body>
    <h1>SlickUpload Quick Start</h1>
    <form id="form1" runat="server">
        <kw:SlickUpload ID="SlickUpload1" runat="server" 
            ShowDuringUploadElements="cancelButton" OnUploadComplete="SlickUpload1_UploadComplete">
            <downlevelselectortemplate>
                <input type="file" />
            </downlevelselectortemplate>
            <uplevelselectortemplate>
                <input type="button" value="Add File" />
            </uplevelselectortemplate>
            <filetemplate>
                <kw:FileListRemoveLink ID="FileListRemoveLink1" runat="server">
                    [x] remove</kw:FileListRemoveLink>
                <kw:FileListFileName ID="FileListFileName1" runat="server" />
                <kw:FileListValidationMessage ID="FileListValidationMessage1" runat="server" ForeColor="Red" />
            </filetemplate>
            <progresstemplate>
                <table width="100%">
                    <tr>
                        <td>
                            Uploading
                            <kw:UploadProgressElement ID="UploadProgressElement1" runat="server" Element="FileCountText">
                            </kw:UploadProgressElement>
                            ,
                            <kw:UploadProgressElement ID="UploadProgressElement2" runat="server" Element="ContentLengthText">
                                (calculating)</kw:UploadProgressElement>
                            .
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Currently uploading:
                            <kw:UploadProgressElement ID="UploadProgressElement3" runat="server" Element="CurrentFileName">
                            </kw:UploadProgressElement>
                            , file
                            <kw:UploadProgressElement ID="UploadProgressElement4" runat="server" Element="CurrentFileIndex">
                                &nbsp;</kw:UploadProgressElement>
                            of
                            <kw:UploadProgressElement ID="UploadProgressElement5" runat="server" Element="FileCount">
                            </kw:UploadProgressElement>
                            .
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Speed:
                            <kw:UploadProgressElement ID="UploadProgressElement6" runat="server" Element="SpeedText">
                                (calculating)</kw:UploadProgressElement>
                            .
                        </td>
                    </tr>
                    <tr>
                        <td>
                            About
                            <kw:UploadProgressElement ID="UploadProgressElement7" runat="server" Element="TimeRemainingText">
                                (calculating)</kw:UploadProgressElement>
                            remaining.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="border:1px solid #008800;height:1.5em;position:relative">
                                <kw:UploadProgressBarElement ID="UploadProgressBarElement1" runat="server" 
                                    style="background-color:#00ee00;width:0;height:1.5em">
                                </kw:UploadProgressBarElement>
                                <div style="text-align:center;position:absolute;top:.15em;width:100%">
                                    <kw:UploadProgressElement ID="UploadProgressElement8" runat="server" Element="PercentCompleteText">
                                        (calculating)</kw:UploadProgressElement>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </progresstemplate>
        </kw:SlickUpload>
    <hr />
        <asp:Button ID="Button1" runat="server" Text="Upload" />
        &nbsp;<asp:Button ID="cancelButton" runat="server" 
            onclientclick="cancelUpload();return false;" Text="Cancel" style="display:none" />
        <br />
        <br />
        <asp:Label ID="uploadResult" runat="server"></asp:Label>
        <asp:Repeater ID="uploadFileList" runat="server" EnableViewState="False">
            <FooterTemplate></ul></FooterTemplate>
            <ItemTemplate><li><%# DataBinder.Eval(Container.DataItem, "ClientName") %></li></ItemTemplate>
            <HeaderTemplate><ul></HeaderTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
