<%@ Page Language="vb" AutoEventWireup="true" Inherits="SamplesVB.FileNameGenerator._Default" CodeBehind="Default.aspx.vb" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<%@ Import Namespace="Krystalware.SlickUpload.Providers" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
<%@ Register Src="Description.ascx" TagPrefix="kw" TagName="Description" %>
<%@ Register Src="~/Common/AfterContent.ascx" TagPrefix="kw" TagName="AfterContent" %>
<%@ Register Src="~/Common/MiddleContent.ascx" TagPrefix="kw" TagName="MiddleContent" %>
<%@ Register Src="~/Common/BeforeContent.ascx" TagPrefix="kw" TagName="BeforeContent" %>
<kw:BeforeContent runat="server" Title="FileNameGenerator" id="BeforeContent1" />
<form runat="server">
	<div ID="uploadPanel" runat="server">
		<div id="fileSelectText">Select files to upload:</div>
		<kw:SlickUpload ID="SlickUpload1" runat="server" ShowDuringUploadElements="cancelLink" onuploadcomplete="SlickUpload1_UploadComplete"
			UploadUrl="~/FileNameGenerator/SlickUpload.axd">
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
		<p>
			<asp:Button id="uploadButton" runat="server" Text="Upload Files" />
			<a id="cancelLink" href="javascript:kw.get('<%=SlickUpload1.ClientID%>').cancel()" style="DISPLAY:none">
				Cancel</a>
		</p>
	</div>
	<div ID="resultPanel" runat="server" Visible="false">
		<h2>Upload Results</h2>
		<p>Result:
			<%=SlickUpload1.UploadStatus.State.ToString()%>
			<%If Not (SlickUpload1.UploadStatus.State = UploadState.Complete OrElse SlickUpload1.UploadStatus.State = UploadState.PostProcessingComplete) Then%>
			<br>
			Reason:
			<%=SlickUpload1.UploadStatus.Reason.ToString()%>
			<% End If%>
			<br>
			Files Uploaded:
			<%=IIf(Not SlickUpload1.UploadedFiles Is Nothing, SlickUpload1.UploadedFiles.Count.ToString(), "N/A")%>
		</p>
		<asp:Repeater ID="resultsRepeater" runat="server">
			<HeaderTemplate>
				<table class="results" width="99%" cellpadding="4" cellspacing="0">
					<thead>
						<tr>
							<th align="left">
								Name</th>
							<th align="left">
								Server Location</th>
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
					<td><%#DirectCast(Container.DataItem, UploadedFile).ClientName%></td>
					<td>~<%#DirectCast(Container.DataItem, UploadedFile).LocationInfo(FileUploadStreamProvider.FileNameKey).Substring(Server.MapPath("~/").Length - 1).Replace("\"c, "/"c)%></td>
					<td><%#DirectCast(Container.DataItem, UploadedFile).ContentType%></td>
					<td><%#DirectCast(Container.DataItem, UploadedFile).ContentLength%></td>
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
