<%@ Page Title="Custom Progress" Language="VB" MasterPageFile="~/Common/Site.master" AutoEventWireup="false" CodeFile="DefaultVB.aspx.vb" Inherits="CustomProgress_DefaultVB" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<%@ Import Namespace="Krystalware.SlickUpload.Providers" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickProgress"
    TagPrefix="kw" %>
<%@ Register Src="Description.ascx" TagPrefix="kw" TagName="Description" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function SlickUpload_OnClientProgressUpdate(data)
        {
            var postProcessProgress = document.getElementById("postProcessProgress");

            // if we're postprocessing now, show the postprocessing progress section
            if (postProcessProgress.style.display == "none" && data.state == "PostProcessing")
            {
                var fileSelectText = document.getElementById("fileSelectText");
                var uploadProgress = document.getElementById("uploadProgress");

                fileSelectText.style.display = uploadProgress.style.display = "none";
                postProcessProgress.style.display = "";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <form id="Form1" runat="server">
    <asp:Panel ID="uploadPanel" runat="server">
        <div id="fileSelectText">Select files to upload:</div>
        <kw:SlickUpload ID="SlickUpload1" runat="server" 
            ShowDuringUploadElements="cancelLink" HasPostProcessStep="true"
            UploadUrl="~/CustomProgress/SlickUpload.axd" OnClientProgressUpdate="SlickUpload_OnClientProgressUpdate">
            <DownlevelSelectorTemplate>
                <input type="file" />
            </DownlevelSelectorTemplate>
            <UplevelSelectorTemplate>
                <input type="button" value="Add File" />
            </UplevelSelectorTemplate>
            <FileTemplate>
                <kw:FileListRemoveLink ID="FileListRemoveLink1" runat="server" Title="Remove">
                    [x]
                </kw:FileListRemoveLink>
                <kw:FileListFileName ID="FileListFileName1" runat="server" />
                <kw:FileListValidationMessage ID="FileListValidationMessage1" runat="server" ForeColor="Red" />
            </FileTemplate>
            <ProgressTemplate>
                <table width="99%" id="uploadProgress">
                    <tr>
                        <td>
                            Uploading <kw:UploadProgressElement runat="server" Element="FileCountText" />,
                            <kw:UploadProgressElement runat="server" Element="ContentLengthText">(calculating)</kw:UploadProgressElement>.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Currently uploading:
                            <kw:UploadProgressElement runat="server" Element="CurrentFileName" />,
                            file <kw:UploadProgressElement runat="server" Element="CurrentFileIndex">&nbsp;</kw:UploadProgressElement>
                            of
                            <kw:UploadProgressElement runat="server" Element="FileCount" />.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Speed:
                            <kw:UploadProgressElement runat="server" Element="SpeedText">(calculating)</kw:UploadProgressElement>.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            About
                            <kw:UploadProgressElement runat="server" Element="TimeRemainingText">(calculating)</kw:UploadProgressElement> remaining.
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="border: 1px solid #008800; height: 1.5em; position: relative">
                                <kw:UploadProgressBarElement runat="server" Style="background-color: #00ee00; width: 0; height: 1.5em" />
                                <div style="text-align: center; position: absolute; top: .15em; width: 100%">
                                    <kw:UploadProgressElement runat="server" Element="PercentCompleteText">(calculating)</kw:UploadProgressElement>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="99%" id="postProcessProgress" style="display:none">
                    <tr>
                        <td>
                            Post processing files
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="border: 1px solid #008800; height: 1.5em; position: relative">
                                <kw:ProgressBarElement runat="server" Style="background-color: #00ee00; width: 0; height: 1.5em" ElementKey="percentComplete" />
                                <div style="text-align: center; position: absolute; top: .15em; width: 100%">
                                    <kw:ProgressElement runat="server" ElementKey="percentCompleteText">(calculating)</kw:ProgressElement>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ProgressTemplate>
        </kw:SlickUpload>
        <p>
            <asp:Button id="uploadButton" runat="server" Text="Upload Files" />
            <a id="cancelLink" href="javascript:kw.get('<%=SlickUpload1.ClientID%>').cancel()" style="display:none">Cancel</a>
        </p>
    </asp:Panel>
    <asp:Panel ID="resultPanel" runat="server" Visible="false">
        <h2>Upload Results</h2>
        <p>Result: <%=SlickUpload1.UploadStatus.State.ToString()%>
        <%If Not (SlickUpload1.UploadStatus.State = UploadState.Complete OrElse SlickUpload1.UploadStatus.State = UploadState.PostProcessingComplete) Then%>
        <br />Reason: <%=SlickUpload1.UploadStatus.Reason.ToString()%>
        <% End If%>
        <br />Files Uploaded: <%=IIf(Not SlickUpload1.UploadedFiles Is Nothing, SlickUpload1.UploadedFiles.Count.ToString(), "N/A")%></p>
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
                    <td><%#DirectCast(Container.DataItem, UploadedFile).ClientName%></td>
                    <td><%#DirectCast(Container.DataItem, UploadedFile).ContentType%></td>
                    <td><%#DirectCast(Container.DataItem, UploadedFile).ContentLength%></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <p><asp:Button id="newUploadButton" runat="server" Text="New Upload" /></p>
    </asp:Panel>
    </form>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="description" Runat="Server">
    <kw:Description ID="Description1" runat="server" />
</asp:Content>