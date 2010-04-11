<%@ Register Src="~/Common/AfterContent.ascx" TagPrefix="kw" TagName="AfterContent" %>
<%@ Register Src="~/Common/MiddleContent.ascx" TagPrefix="kw" TagName="MiddleContent" %>
<%@ Register Src="~/Common/BeforeContent.ascx" TagPrefix="kw" TagName="BeforeContent" %>
<%@ Register Src="Description.ascx" TagPrefix="kw" TagName="Description" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Page Language="c#" AutoEventWireup="true" Inherits="SamplesCS.Overview.Default" CodeBehind="Default.aspx.cs" %>
<kw:BeforeContent runat="server" Title="Overview" id="BeforeContent1" />
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
            document.getElementById("<%= validExtensionsSpan.ClientID %>").style.display = "none";
            document.getElementById("<%= invalidExtensionMessageSpan.ClientID %>").style.display = "none";
            document.getElementById("<%= validationSummaryMessageSpan.ClientID %>").style.display = "none";

            document.getElementById("<%= maxFilesTextBox.ClientID %>").style.display = "";
            document.getElementById("<%= requireFileCheckBox.ClientID %>").parentNode.style.display = "";
            document.getElementById("<%= validExtensionsTextBox.ClientID %>").style.display = "";
            document.getElementById("<%= invalidExtensionMessageTextBox.ClientID %>").style.display = "";
            document.getElementById("<%= validationSummaryMessageTextBox.ClientID %>").style.display = "";
        }
</script>
<form id="Form1" runat="server">
	<div style="BORDER-RIGHT:#ccc 1px solid; PADDING-RIGHT:0.5em; BORDER-TOP:#ccc 1px solid; PADDING-LEFT:0.5em; MARGIN-BOTTOM:1em; PADDING-BOTTOM:0.5em; BORDER-LEFT:#ccc 1px solid; PADDING-TOP:0.5em; BORDER-BOTTOM:#ccc 1px solid"
		id="settingsBox" runat="server">
		<table class="settings" id="settingsTable">
			<tbody>
				<tr>
					<th colspan="3">
						General Settings</th>
				</tr>
				<tr>
					<th width="160">
						Max Files:</th>
					<td>
						<span id="maxFilesSpan" runat="server"></span>
						<asp:TextBox ID="maxFilesTextBox" runat="server" style="DISPLAY:none" />
					</td>
					<td><em>Number of files, or -1 for unlimited</em></td>
				</tr>
				<tr>
					<th>
						Require file selection:</th>
					<td colspan="2">
						<span id="requireFileSpan" runat="server"></span>
						<asp:CheckBox ID="requireFileCheckBox" runat="server" style="DISPLAY:none" />
					</td>
				</tr>
				<tr>
					<th colspan="3">
						Validation</th>
				</tr>
				<tr>
					<th>
						Valid Extensions:</th>
					<td>
						<span id="validExtensionsSpan" runat="server"></span>
						<asp:TextBox ID="validExtensionsTextBox" runat="server" style="DISPLAY:none" />
					</td>
					<td><em>Comma seperated list of valid extensions</em></td>
				</tr>
				<tr>
					<th>
						Per file message:</th>
					<td>
						<span id="invalidExtensionMessageSpan" runat="server"></span>
						<asp:TextBox ID="invalidExtensionMessageTextBox" runat="server" style="DISPLAY:none" />
					</td>
					<td><em>Message to display next to invalid files</em></td>
				</tr>
				<tr>
					<th>
						Summary message:</th>
					<td>
						<span id="validationSummaryMessageSpan" runat="server"></span>
						<asp:TextBox ID="validationSummaryMessageTextBox" runat="server" style="DISPLAY:none" />
					</td>
					<td><em>Summary validation message for invalid files</em></td>
				</tr>
			</tbody>
		</table>
		<br>
		<input id="editSettingsButton" type="button" onclick="startSettingsEdit()" value="Edit Settings">
		<asp:Button ID="saveSettingsButton" runat="server" Text="Save Settings" onclick="saveSettingsButton_Click"
			CausesValidation="false" style="DISPLAY:none" />
		<asp:Button ID="cancelSettingsButton" runat="server" Text="Cancel" CausesValidation="false"
			style="DISPLAY:none" />
	</div>
	<div ID="uploadPanel" runat="server">
		<div style="BORDER-RIGHT:#ccc 1px solid; PADDING-RIGHT:0.5em; BORDER-TOP:#ccc 1px solid; PADDING-LEFT:0.5em; MARGIN-BOTTOM:1em; PADDING-BOTTOM:0.5em; BORDER-LEFT:#ccc 1px solid; PADDING-TOP:0.5em; BORDER-BOTTOM:#ccc 1px solid"
			id="Div1" runat="server">
			<table class="settings">
				<tbody>
					<tr id="fileSelectText">
						<th>
							Select files to upload:</th>
					</tr>
					<tr>
						<td>
							<kw:SlickUpload ID="SlickUpload1" runat="server" ShowDuringUploadElements="cancelLink" HideDuringUploadElements="fileSelectText,uploadButton"
								OnUploadComplete="SlickUpload1_UploadComplete" UploadUrl="~/Overview/SlickUpload.axd" AutoUploadOnPostBack="false">
            <DownlevelSelectorTemplate>
                <input type="file" />
            </DownlevelSelectorTemplate>
            <UplevelSelectorTemplate>
                <input type="button" value="Add File" />
            </UplevelSelectorTemplate>
								<FileTemplate>
									<kw:FileListRemoveLink ID="FileListRemoveLink1" runat="server" Title="Remove">
										<img width="20" height="20" style="vertical-align:text-bottom" src='<%=ResolveUrl("~/Common/delete.png") %>' />
									</kw:FileListRemoveLink>
									<kw:FileListFileName ID="FileListFileName1" runat="server" />
									<kw:FileListValidationMessage ID="FileListValidationMessage1" runat="server" ForeColor="Red" />
								</FileTemplate>
								<ProgressTemplate>
									<table width="99%">
										<tr>
											<td>
												Uploading
												<kw:UploadProgressElement id="UploadProgressElement1" runat="server" Element="FileCountText" />,
												<kw:UploadProgressElement id="UploadProgressElement2" runat="server" Element="ContentLengthText">(calculating)</kw:UploadProgressElement>.
											</td>
										</tr>
										<tr>
											<td>
												Currently uploading:
												<kw:UploadProgressElement id="UploadProgressElement3" runat="server" Element="CurrentFileName" />, 
												file
												<kw:UploadProgressElement id="UploadProgressElement4" runat="server" Element="CurrentFileIndex">&nbsp;</kw:UploadProgressElement>
												of
												<kw:UploadProgressElement id="UploadProgressElement5" runat="server" Element="FileCount" />.
											</td>
										</tr>
										<tr>
											<td>
												Speed:
												<kw:UploadProgressElement id="UploadProgressElement6" runat="server" Element="SpeedText">(calculating)</kw:UploadProgressElement>.
											</td>
										</tr>
										<tr>
											<td>
												About
												<kw:UploadProgressElement id="UploadProgressElement7" runat="server" Element="TimeRemainingText">(calculating)</kw:UploadProgressElement>
												remaining.
											</td>
										</tr>
										<tr>
											<td>
												<div style="border: 1px solid #008800; height: 1.5em; position: relative">
													<kw:UploadProgressBarElement id="UploadProgressBarElement1" runat="server" Style="background-color: #00ee00; width: 0; height: 1.5em" />
													<div style="text-align: center; position: absolute; top: .15em; width: 100%">
														<kw:UploadProgressElement id="UploadProgressElement8" runat="server" Element="PercentCompleteText">(calculating)</kw:UploadProgressElement>
													</div>
												</div>
											</td>
										</tr>
									</table>
								</ProgressTemplate>
							</kw:SlickUpload>
							<asp:CustomValidator ID="requiredFilesValidator" runat="server" ClientValidationFunction="Validate_SlickUploadRequiredFiles"
								Text="Please select at least one file to upload." Display="Dynamic" />
							<asp:CustomValidator ID="extensionValidator" runat="server" ClientValidationFunction="Validate_SlickUploadValidExtensions"
								Display="Dynamic" />
						</td>
					</tr>
				</tbody></table>
		</div>
		<p>
			<input type="button" id="uploadButton" onclick="kw.get('<%=SlickUpload1.ClientID%>').submit();return false;" value="Upload Files" >
			<a id="cancelLink" href="javascript:kw.get('<%=SlickUpload1.ClientID%>').cancel()" style="DISPLAY:none">
				Cancel</a>
		</p>
	</div>
	<div ID="resultPanel" runat="server" Visible="false">
		<h2>Upload Results</h2>
		<p>Result:
			<%=SlickUpload1.UploadStatus.State %>
			<%if (!(SlickUpload1.UploadStatus.State == UploadState.Complete || SlickUpload1.UploadStatus.State == UploadState.PostProcessingComplete)) { %>
			<br>
			Reason:
			<%=SlickUpload1.UploadStatus.Reason%>
			<% } %>
			<br>
			Files Uploaded:
			<%=SlickUpload1.UploadedFiles != null ? SlickUpload1.UploadedFiles.Count.ToString() : "N/A"%>
		</p>
		<asp:Repeater ID="resultsRepeater" runat="server">
			<HeaderTemplate>
				<table class="results" width="99%" cellpadding="4" cellspacing="0">
					<thead>
						<tr>
							<th align="left">
								Name</th>
							<th align="left">
								Mime Type</th>
							<th align="left">
								Length (bytes)</th>
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
		<p><asp:Button id="newUploadButton" runat="server" Text="New Upload" onclick="newUploadButton_Click" /></p>
	</div>
</form>
<kw:MiddleContent runat="server" id="MiddleContent1" />
<kw:Description runat="server" id="Description1" />
<kw:AfterContent runat="server" id="AfterContent1" />
