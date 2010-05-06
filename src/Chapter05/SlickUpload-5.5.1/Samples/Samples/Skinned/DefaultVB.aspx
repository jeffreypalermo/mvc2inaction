<%@ Page Title="Skinned" Language="VB" MasterPageFile="~/Common/Site.master" AutoEventWireup="false" CodeFile="DefaultVB.aspx.vb" Inherits="Skinned_DefaultVB" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<%@ Import Namespace="Krystalware.SlickUpload.Providers" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
<%@ Register Src="Description.ascx" TagPrefix="kw" TagName="Description" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function fileAdded(file)
        {
            var extImage = file.getElementById("extImage");
            
            extImage.src = "FileIconVB.ashx?ext=" + file.extension;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <form id="Form1" runat="server">
    <asp:Panel ID="uploadPanel" runat="server">
        <div id="fileSelectText">Select files to upload:</div>
        <kw:SlickUpload ID="SlickUpload1" runat="server" 
            ShowDuringUploadElements="cancelLink" 
            UploadUrl="~/Skinned/SlickUpload.axd" OnClientFileAdded="fileAdded">
            <DownlevelSelectorTemplate>
                <input type="file" />
            </DownlevelSelectorTemplate>
            <UplevelSelectorTemplate>
                <input type="button" value="Add File" />
            </UplevelSelectorTemplate>
            <FileTemplate>
                <div style="border:solid 1px #ccc;margin:1em;padding:1em">
                    <kw:FileListRemoveLink ID="FileListRemoveLink1" runat="server" Title="Remove" style="float:right;margin-top:-.5em;margin-right:-.5em">
                        <img width="20" height="20" style="vertical-align:middle" src="<%=ResolveUrl("~/Common/delete.png") %>" /> remove
                    </kw:FileListRemoveLink>
                    <img id="extImage" width="32" height="32" style="vertical-align:middle;" />
                    <kw:FileListFileName ID="FileListFileName1" runat="server" style="font-size:120%" />
                    <kw:FileListValidationMessage ID="FileListValidationMessage1" runat="server" ForeColor="Red" />
                </div>
            </FileTemplate>
            <ProgressTemplate>
                <table width="99%">
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
                            <div style="border: 1px solid #008800; height: 9px; position: relative">
                                <kw:UploadProgressBarElement ID="UploadProgressBarElement1" runat="server" Style="background-image: url('xp.gif'); width: 0; height: 9px" />
                                <div style="text-align: center; width: 100%">
                                    <kw:UploadProgressElement ID="UploadProgressElement1" runat="server" Element="PercentCompleteText">(calculating)</kw:UploadProgressElement>
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