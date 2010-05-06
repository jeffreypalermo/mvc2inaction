<%@ Page Title="Modal Progress" Language="C#" MasterPageFile="~/Common/Site.master" AutoEventWireup="true" CodeFile="DefaultCS.aspx.cs" Inherits="ModalProgress_DefaultCs" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<%@ Import Namespace="Krystalware.SlickUpload.Providers" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
<%@ Register Src="Description.ascx" TagPrefix="kw" TagName="Description" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function showProgressModal()
        {
            // TODO: use whatever modal library you use, or do any repositioning that needs to be done
            positionProgressModal();
        }

        function positionProgressModal()
        {
            var size = getPageDimensions();

            var mask = document.getElementById("modal-mask");
            var modal = document.getElementById("modal");

            if (mask && modal)
            {
                mask.style.width = size.maxWidth + "px";
                mask.style.height = size.maxHeight + "px";

                modal.style.top = size.scrollY + ((size.portHeight - modal.offsetHeight) / 2) + "px";
                modal.style.left = size.scrollX + ((size.portWidth - modal.offsetWidth) / 2) + "px";
            }
        }

        function getPageDimensions()
        {
            var height = 0;
            var width = 0;
            var portHeight = 0;
            var portWidth = 0;
            var scrollY = 0;
            var scrollX = 0;

            if (self.innerHeight)
            {
                portHeight = window.innerHeight;
                portWidth = window.innerWidth;
            }
            else if (document.documentElement && document.documentElement.clientHeight)
            {
                portHeight = document.documentElement.clientHeight;
                portWidth = document.documentElement.clientWidth;
            }
            else if (document.body)
            {
                portHeight = document.body.clientHeight;
                portWidth = document.body.clientWidth;
            }

            if (window.innerHeight && window.scrollMaxY)
            {
                height = window.innerHeight + window.scrollMaxY;
                width = window.innerWidth + window.scrollMaxX;
            }
            else if (document.body.scrollHeight > document.body.offsetHeight)
            {
                height = document.body.scrollHeight;
                width = document.body.scrollWidth;
            }
            else
            {
                height = document.body.offsetHeight + document.body.offsetTop;
                width = document.body.offsetWidth + document.body.offsetLeft;
            }

            if (document.body.scrollTop)
            {
                scrollY = document.body.scrollTop;
                scrollX = document.body.scrollLeft;
            }
            else if (document.documentElement)
            {
                scrollY = document.documentElement.scrollTop;
                scrollX = document.documentElement.scrollLeft;
            }
            else
            {
                scrollY = self.pageYOffset;
                scrollX = self.pageXOffset;
            }

            var value = ({
                height: parseInt(height, 10),
                width: parseInt(width, 10),
                portHeight: parseInt(portHeight, 10),
                portWidth: parseInt(portWidth, 10),
                scrollY: parseInt(scrollY, 10),
                scrollX: parseInt(scrollX, 10)
            });

            value.maxHeight = value.portHeight > value.height ? value.portHeight : value.height;
            value.maxWidth = value.portWidth > value.width ? value.portWidth : value.width;

            return value;
        }

        window.onresize = positionProgressModal;
        window.onscroll = positionProgressModal;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <form runat="server">
    <asp:Panel ID="uploadPanel" runat="server">
        <div id="fileSelectText">Select files to upload:</div>
        <kw:SlickUpload ID="SlickUpload1" runat="server" 
            onuploadcomplete="SlickUpload1_UploadComplete" UploadUrl="~/ModalProgress/SlickUpload.axd" OnClientUploadStarted="showProgressModal">
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
                <div id="modal-mask" style="position:absolute;left:0;top:0;right:0;bottom:0;background-color:#000;opacity:.5;filter: alpha(opacity=50);-moz-opacity: .5;"></div>
                <div id="modal" style="position:absolute;border:solid 1px #888;width:50%;background-color:#fff;padding:1em">
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
                    <p style="margin-bottom:0;padding-bottom:0">
                        <a id="cancelLink" href="javascript:kw.get('<%=SlickUpload1.ClientID%>').cancel()">Cancel</a>
                    </p>
                </div>
            </ProgressTemplate>
        </kw:SlickUpload>
        <p>
            <asp:Button id="uploadButton" runat="server" Text="Upload Files" />
        </p>
    </asp:Panel>
    <asp:Panel ID="resultPanel" runat="server" Visible="false">
        <h2>Upload Results</h2>
        <p>Result: <%=SlickUpload1.UploadStatus.State %>
        <%if (!(SlickUpload1.UploadStatus.State == UploadState.Complete || SlickUpload1.UploadStatus.State == UploadState.PostProcessingComplete)) { %>
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
        <p><asp:Button id="newUploadButton" runat="server" Text="New Upload" 
                onclick="newUploadButton_Click" /></p>
    </asp:Panel>
    </form>
</asp:Content>
<asp:Content ContentPlaceHolderID="description" Runat="Server">
    <kw:Description runat="server" />
</asp:Content>