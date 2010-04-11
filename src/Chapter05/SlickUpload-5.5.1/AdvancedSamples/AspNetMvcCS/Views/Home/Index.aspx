<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Register TagPrefix="kw" Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls" %>
<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%= Html.Encode(ViewData["Message"]) %></h2>
    <% using (Html.BeginForm("UploadResult", "Home", FormMethod.Post, new { id = "uploadForm", enctype = "multipart/form-data" })) { %>
        <kw:SlickUpload ID="SlickUpload1" runat="server" UploadFormId="uploadForm" ShowDuringUploadElements="cancelButton" HideDuringUploadElements="uploadButton">
            <DownlevelSelectorTemplate>
                <input type="file" />
            </DownlevelSelectorTemplate>
            <UplevelSelectorTemplate>
                <input type="button" value="Add File" />
            </UplevelSelectorTemplate>
            <FileTemplate>
                <kw:FileListRemoveLink runat="server">[x] remove</kw:FileListRemoveLink>
                <kw:FileListFileName runat="server" />
                <kw:FileListValidationMessage runat="server" ForeColor="Red" />
            </FileTemplate>
            <ProgressTemplate>
                <table width="99%">
                    <tr>
                        <td>
                            Uploading <kw:UploadProgressElement ID="UploadProgressElement1" runat="server" Element="FileCountText" />,
                            <kw:UploadProgressElement ID="UploadProgressElement2" runat="server" Element="ContentLengthText">(calculating)</kw:UploadProgressElement>.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Currently uploading:
                            <kw:UploadProgressElement ID="UploadProgressElement3" runat="server" Element="CurrentFileName" />,
                            file <kw:UploadProgressElement ID="UploadProgressElement4" runat="server" Element="CurrentFileIndex">&nbsp;</kw:UploadProgressElement>
                            of
                            <kw:UploadProgressElement ID="UploadProgressElement5" runat="server" Element="FileCount" />.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Speed:
                            <kw:UploadProgressElement ID="UploadProgressElement6" runat="server" Element="SpeedText">(calculating)</kw:UploadProgressElement>.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            About
                            <kw:UploadProgressElement ID="UploadProgressElement7" runat="server" Element="TimeRemainingText">(calculating)</kw:UploadProgressElement> remaining.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="border: 1px solid #008800; height: 1.5em; position: relative">
                                <kw:UploadProgressBarElement ID="UploadProgressBarElement1" runat="server" Style="background-color: #00ee00; width: 0; height: 1.5em" />
                                <div style="text-align: center; position: absolute; top: .15em; width: 100%">
                                    <kw:UploadProgressElement ID="UploadProgressElement8" runat="server" Element="PercentCompleteText">(calculating)</kw:UploadProgressElement>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ProgressTemplate>
        </kw:SlickUpload>
        <p>
            <input type="submit" value="Upload" id="uploadButton" />
            <a href="javascript:kw.get('<%=SlickUpload1.ClientID %>').cancel()" id="cancelButton" style="display:none">Cancel</a>
        </p>            
    <% } %>
</asp:Content>
