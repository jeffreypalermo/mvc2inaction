<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AspNetAjaxCS._Default" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>SlickUpload ASP.NET AJAX Sample</title>
    <script type="text/javascript">
        function startUpload()
        {
            kw.get('<%=SlickUpload1.ClientID %>').submit();
        }
    </script>
</head>
<body>
    <h1>SlickUpload ASP.NET AJAX Sample</h1>
    <form runat="server">
        <asp:ScriptManager ID="ScriptManager" runat="server" EnablePartialRendering="true">
        </asp:ScriptManager>               
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
            <ContentTemplate>
                <div style="border:2px dotted #ccc;padding:1em">
                <asp:Repeater ID="ExistingImagesRepeater" runat="server" OnItemCommand="ExistingImagesRepeater_ItemCommand">
                    <ItemTemplate>
                        bla
                        <asp:LinkButton ID="RemoveLinkButton" runat="server" Text="[ remove ]" CommandName="RemoveImage" />
                        <br />
                    </ItemTemplate>
                </asp:Repeater>
                    <h2>UpdatePanel</h2>
                    <p>Time: <asp:Label ID="updateLabel" runat="server" /></p>
                    <p><asp:Button ID="updateButton" runat="server" Text="Update Time" 
                            onclick="updateButton_Click" /></p>
                    <h2>Select files</h2>
                    <asp:Panel ID="uploadPanel" runat="server">
                        <kw:FileSelector ID="fileSelector" runat="server" Visible="false">
                            <DownlevelTemplate>
                                <input type="file" />
                            </DownlevelTemplate>
                            <UplevelTemplate>
                                <input type="button" value="Add File" />
                            </UplevelTemplate>
                        </kw:FileSelector>
                        <kw:FileList ID="fileList"  FileSelectorId="fileSelector"  runat="server" Visible="false">
                            <FileTemplate>
                                <kw:FileListRemoveLink ID="FileListRemoveLink1" runat="server">
                                    [x] remove</kw:FileListRemoveLink>
                                <kw:FileListFileName ID="FileListFileName1" runat="server" />
                                <kw:FileListValidationMessage ID="FileListValidationMessage1" runat="server" ForeColor="Red" />
                            </FileTemplate>
                        </kw:FileList>
                        <p>
                            <asp:Button runat="server" Text="Upload" OnClientClick="startUpload();return false;" />
                            <a href="javascript:kw.get('<%=SlickUpload1.ClientID %>').cancel()" id="cancelButton" style="display:none">Cancel</a>
                        </p>            
                    </asp:Panel>
                    <asp:Panel ID="resultPanel" runat="server" Visible="false">
                        <h2>Upload Results</h2>
                        <% if (SlickUpload1.UploadStatus != null) { %>
                        <p>Result: <%=SlickUpload1.UploadStatus.State%>
                        <%if (!(SlickUpload1.UploadStatus.State == UploadState.Complete || SlickUpload1.UploadStatus.State == UploadState.PostProcessingComplete))
                          { %>
                        <br />Reason: <%=SlickUpload1.UploadStatus.Reason%>
                        <% } %>
                        <br />Files Uploaded: <%=SlickUpload1.UploadedFiles != null ? SlickUpload1.UploadedFiles.Count.ToString() : "N/A"%></p>
                        <asp:Repeater ID="resultsRepeater" runat="server">
                            <HeaderTemplate>
                                <table class="results" width="99%" cellpadding="4" cellspacing="0">
                                    <thead>
                                        <tr>
                                            <th align="left">Name</th>
                                            <th align="left">Mime Type</th>
                                            <th align="left">Length (bytes)</th>
                                        </tr>
                                    </thead>
                                    <tbody>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%#((UploadedFile)Container.DataItem).ClientName %></td>
                                    <td><%#((UploadedFile)Container.DataItem).ContentType %></td>
                                    <td><%#((UploadedFile)Container.DataItem).ContentLength %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                    </tbody>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                        <% } %>
                        <p><asp:Button id="newUploadButton" runat="server" Text="New Upload" 
                                onclick="newUploadButton_Click" /></p>
                    </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>                    

        <%--<asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Always" ChildrenAsTriggers="true">
            <ContentTemplate>
                        <kw:FileSelector ID="fileSelector1" runat="server" Visible="true">
                            <DownlevelTemplate>
                                <input type="file" />
                            </DownlevelTemplate>
                            <UplevelTemplate>
                                <input type="button" value="Add File" />
                            </UplevelTemplate>
                        </kw:FileSelector>
                        <kw:FileList ID="fileList1" FileSelectorId="fileSelector1" runat="server" Visible="true">
                            <FileTemplate>
                                <kw:FileListRemoveLink ID="FileListRemoveLink1" runat="server">
                                    [x] remove</kw:FileListRemoveLink>
                                <kw:FileListFileName ID="FileListFileName1" runat="server" />
                                <kw:FileListValidationMessage ID="FileListValidationMessage1" runat="server" ForeColor="Red" />
                            </FileTemplate>
                        </kw:FileList>
                                    </ContentTemplate>
        </asp:UpdatePanel>--%>
                        <kw:UploadProgressDisplay ID="uploadProgressDisplay" runat="server">
                            <ProgressTemplate>
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
                                            <div style="border: 1px solid #008800; height: 1.5em; position: relative">
                                                <kw:UploadProgressBarElement ID="UploadProgressBarElement1" runat="server" Style="background-color: #00ee00;
                                                    width: 0; height: 1.5em">
                                                </kw:UploadProgressBarElement>
                                                <div style="text-align: center; position: absolute; top: .15em; width: 100%">
                                                    <kw:UploadProgressElement ID="UploadProgressElement8" runat="server" Element="PercentCompleteText">
                                                        (calculating)</kw:UploadProgressElement>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </ProgressTemplate>
                        </kw:UploadProgressDisplay>
                        <kw:UploadConnector ID="SlickUpload1" runat="server" AutoUploadOnPostBack="false" ShowDuringUploadElements="cancelButton" HideDuringUploadElements="uploadButton" OnUploadComplete="SlickUpload1_UploadComplete" />

    </form>
</body>
</html>
