<%@ Page Title="Overview" Language="VB" MasterPageFile="~/Common/Site.master" AutoEventWireup="false" CodeFile="DefaultVB.aspx.vb" Inherits="Overview_DefaultVB" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
<%@ Register Src="Description.ascx" TagPrefix="kw" TagName="Description" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <script type="text/javascript">
        function Validate_SlickUploadRequiredFiles(source, args)
        {
            args.IsValid = (kw.get("<%=SlickUpload1.ClientID %>").get_Files().length > 0);
        }

        function Validate_SlickUploadValidExtensions(source, args)
        {
            var files = kw.get("<%=SlickUpload1.ClientID %>").get_Files();

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
        function startSettingsEdit()
        {
            document.getElementById("<%=settingsBox.ClientID%>").style.backgroundColor = "#ffffe0";

            document.getElementById("editSettingsButton").style.display = "none";

            document.getElementById("<%=saveSettingsButton.ClientID%>").style.display = "";
            document.getElementById("<%=cancelSettingsButton.ClientID%>").style.display = "";

            document.getElementById("<%= maxFilesSpan.ClientID %>").style.display = "none";
            document.getElementById("<%= requireFileSpan.ClientID %>").style.display = "none";
            document.getElementById("<%= confirmNavigateSpan.ClientID %>").style.display = "none";
            document.getElementById("<%= validExtensionsSpan.ClientID %>").style.display = "none";
            document.getElementById("<%= invalidExtensionMessageSpan.ClientID %>").style.display = "none";
            document.getElementById("<%= validationSummaryMessageSpan.ClientID %>").style.display = "none";

            document.getElementById("<%= maxFilesTextBox.ClientID %>").style.display = "";
            document.getElementById("<%= requireFileCheckBox.ClientID %>").parentNode.style.display = "";
            document.getElementById("<%= confirmNavigateTextBox.ClientID %>").style.display = "";
            document.getElementById("<%= validExtensionsTextBox.ClientID %>").style.display = "";
            document.getElementById("<%= invalidExtensionMessageTextBox.ClientID %>").style.display = "";
            document.getElementById("<%= validationSummaryMessageTextBox.ClientID %>").style.display = "";
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
        <form id="Form1" runat="server">
        <div style="border:solid 1px #ccc;padding:.5em;margin-bottom:1em;" id="settingsBox" runat="server">
            <table class="settings" id="settingsTable">
                <tbody>
                    <tr>
                        <th colspan="3" style="font-weight:bold;border-bottom:solid 1px #ccc">General Settings</th>
                    </tr>
                    <tr>
                        <th style="width:12em">Max files:</th>
                        <td style="vertical-align:middle">                            
                            <span id="maxFilesSpan" runat="server"></span>
                            <asp:TextBox ID="maxFilesTextBox" runat="server" style="display:none" />
                        </td>
                        <td style="text-align:right"><em>Number of files, or -1 for unlimited</em></td>
                    </tr>
                    <tr>
                        <th>Require file selection:</th>
                        <td colspan="2">
                            <span id="requireFileSpan" runat="server"></span>
                            <asp:CheckBox ID="requireFileCheckBox" runat="server"  style="display:none" />
                        </td>
                    </tr>
                    <tr>
                        <th>Confirm navigate message:</th>
                        <td>
                            <span id="confirmNavigateSpan" runat="server"></span>
                            <asp:TextBox ID="confirmNavigateTextBox" runat="server" style="display:none" />
                        </td>
                        <td style="text-align:right"><em>Prompt when user navigates during upload</em></td>
                    </tr>
                    <tr>
                        <th colspan="3" style="font-weight:bold;border-bottom:solid 1px #ccc">Validation</th>
                    </tr>
                    <tr>
                        <th>Valid extensions:</th>
                        <td>
                            
                            <span id="validExtensionsSpan" runat="server"></span>
                            <asp:TextBox ID="validExtensionsTextBox" runat="server" style="display:none" />
                        </td>
                        <td style="text-align:right"><em>Comma seperated list of valid extensions</em></td>
                    </tr>
                    <tr>
                        <th>Per file message:</th>
                        <td>
                            
                            <span id="invalidExtensionMessageSpan" runat="server"></span>
                            <asp:TextBox ID="invalidExtensionMessageTextBox" runat="server" style="display:none" />
                        </td>
                        <td style="text-align:right"><em>Message to display next to invalid files</em></td>
                    </tr>
                    <tr>
                        <th>Summary message:</th>
                        <td>
                            
                            <span id="validationSummaryMessageSpan" runat="server"></span>
                            <asp:TextBox ID="validationSummaryMessageTextBox" runat="server" style="display:none" />
                        </td>
                        <td style="text-align:right"><em>Summary validation message for invalid files</em></td>
                    </tr>
                </tbody>
            </table>
            <br />
            <input id="editSettingsButton" type="button" onclick="startSettingsEdit()" value="Edit Settings" />
            <asp:Button ID="saveSettingsButton" runat="server" Text="Save Settings" onclick="saveSettingsButton_Click" CausesValidation="false" style="display:none" />
            <asp:Button ID="cancelSettingsButton" runat="server" Text="Cancel" CausesValidation="false" style="display:none" />
        </div>
    <asp:Panel ID="uploadPanel" runat="server">
        <div style="border:solid 1px #ccc;padding:.5em;margin-bottom:1em;" id="Div1" runat="server">
            <table class="settings">
                <tbody>
                    <tr id="fileSelectText">
                        <th style="font-weight:bold;border-bottom:solid 1px #ccc">Select files to upload:</th>
                    </tr>
                    <tr>
                        <td>
        <kw:SlickUpload ID="SlickUpload1" runat="server" 
            ShowDuringUploadElements="cancelLink" HideDuringUploadElements="fileSelectText,uploadButton" 
            UploadUrl="~/Overview/SlickUpload.axd" AutoUploadOnPostBack="false">
            <DownlevelSelectorTemplate>
                <input type="file" />
            </DownlevelSelectorTemplate>
            <UplevelSelectorTemplate>
                <input type="button" value="Add File" />
            </UplevelSelectorTemplate>
            <FileTemplate>
                <kw:FileListRemoveLink ID="FileListRemoveLink1" runat="server" Title="Remove">
                    <img width="20" height="20" style="vertical-align:text-bottom" src="<%=ResolveUrl("~/Common/delete.png") %>" />
                </kw:FileListRemoveLink>
                <kw:FileListFileName ID="FileListFileName1" runat="server" />
                <kw:FileListValidationMessage ID="FileListValidationMessage1" runat="server" ForeColor="Red" />
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
                            <div style="border: 1px solid #008800; height: 1.5em; position: relative">
                                <kw:UploadProgressBarElement runat="server" Style="background-color: #00ee00; width: 0; height: 1.5em" />
                                <div style="text-align: center; position: absolute; top: .15em; width: 100%">
                                    <kw:UploadProgressElement runat="server" Element="PercentCompleteText">(calculating)</kw:UploadProgressElement>
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>
            </ProgressTemplate>
        </kw:SlickUpload>
        <asp:CustomValidator ID="requiredFilesValidator" runat="server" ClientValidationFunction="Validate_SlickUploadRequiredFiles" Text="Please select at least one file to upload." Display="Dynamic" />
        <asp:CustomValidator ID="extensionValidator" runat="server" ClientValidationFunction="Validate_SlickUploadValidExtensions" Display="Dynamic" />
        </td>
                    </tr>
                    </tbody></table></div>
        <p>
            <input type="button" id="uploadButton" onclick="kw.get('<%=SlickUpload1.ClientID%>').submit();return false;" value="Upload Files" />
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