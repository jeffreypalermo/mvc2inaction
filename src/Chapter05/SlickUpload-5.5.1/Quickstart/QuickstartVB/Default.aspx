<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
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
            ShowDuringUploadElements="cancelButton">
            <downlevelselectortemplate>
                <input type="file" />
            </downlevelselectortemplate>
            <uplevelselectortemplate>
                <input type="button" value="Add File" />
            </uplevelselectortemplate>
            <filetemplate>
                <kw:FileListRemoveLink runat="server">
                    [x] remove</kw:FileListRemoveLink>
                <kw:FileListFileName runat="server" />
                <kw:FileListValidationMessage runat="server" ForeColor="Red" />
            </filetemplate>
            <progresstemplate>
                <table width="100%">
                    <tr>
                        <td>
                            Uploading
                            <kw:UploadProgressElement runat="server" Element="FileCountText">
                            </kw:UploadProgressElement>
                            ,
                            <kw:UploadProgressElement runat="server" Element="ContentLengthText">
                                (calculating)</kw:UploadProgressElement>
                            .
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Currently uploading:
                            <kw:UploadProgressElement runat="server" Element="CurrentFileName">
                            </kw:UploadProgressElement>
                            , file
                            <kw:UploadProgressElement runat="server" Element="CurrentFileIndex">
                                &nbsp;</kw:UploadProgressElement>
                            of
                            <kw:UploadProgressElement runat="server" Element="FileCount">
                            </kw:UploadProgressElement>
                            .
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Speed:
                            <kw:UploadProgressElement runat="server" Element="SpeedText">
                                (calculating)</kw:UploadProgressElement>
                            .
                        </td>
                    </tr>
                    <tr>
                        <td>
                            About
                            <kw:UploadProgressElement runat="server" Element="TimeRemainingText">
                                (calculating)</kw:UploadProgressElement>
                            remaining.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="border:1px solid #008800;height:1.5em;position:relative">
                                <kw:UploadProgressBarElement runat="server" 
                                    style="background-color:#00ee00;width:0;height:1.5em">
                                </kw:UploadProgressBarElement>
                                <div style="text-align:center;position:absolute;top:.15em;width:100%">
                                    <kw:UploadProgressElement runat="server" Element="PercentCompleteText">
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
