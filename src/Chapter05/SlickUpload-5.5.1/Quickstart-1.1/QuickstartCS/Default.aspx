<%@ Register assembly="Krystalware.SlickUpload" namespace="Krystalware.SlickUpload.Controls" tagprefix="kw" %>
<%@ Page Language="c#" AutoEventWireup="false" Inherits="QuickstartCS.Default" CodeBehind="Default.aspx.cs" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD id="Head1">
		<title>SlickUpload Quick Start</title>
		<script type="text/javascript">
    function cancelUpload() {
        kw.get("<%=SlickUpload1.ClientID %>").cancel();
    }     
		</script>
	</HEAD>
	<body>
		<h1>SlickUpload Quick Start</h1>
		<form id="form1" runat="server">
			<kw:SlickUpload ID="SlickUpload1" runat="server" onuploadcomplete="SlickUpload1_UploadComplete"
				ShowDuringUploadElements="cancelButton">
				<downlevelselectortemplate>
					<input type="file" />
				</downlevelselectortemplate>
				<uplevelselectortemplate>
					<input type="button" value="Add File" />
				</uplevelselectortemplate>
				<filetemplate>
					<kw:FileListRemoveLink runat="server" ID="Filelistremovelink1">
                    [x] remove</kw:FileListRemoveLink>
					<kw:FileListFileName runat="server" ID="Filelistfilename1" />
					<kw:FileListValidationMessage runat="server" ForeColor="Red" ID="Filelistvalidationmessage1" />
				</filetemplate>
				<progresstemplate>
					<table width="100%">
						<tr>
							<td>
								Uploading
								<kw:UploadProgressElement runat="server" Element="FileCountText" ID="Uploadprogresselement1"></kw:UploadProgressElement>
								,
								<kw:UploadProgressElement runat="server" Element="ContentLengthText" ID="Uploadprogresselement2">
                                (calculating)</kw:UploadProgressElement>
								.
							</td>
						</tr>
						<tr>
							<td>
								Currently uploading:
								<kw:UploadProgressElement runat="server" Element="CurrentFileName" ID="Uploadprogresselement3"></kw:UploadProgressElement>
								, file
								<kw:UploadProgressElement runat="server" Element="CurrentFileIndex" ID="Uploadprogresselement4">
                                &nbsp;</kw:UploadProgressElement>
								of
								<kw:UploadProgressElement runat="server" Element="FileCount" ID="Uploadprogresselement5"></kw:UploadProgressElement>
								.
							</td>
						</tr>
						<tr>
							<td>
								Speed:
								<kw:UploadProgressElement runat="server" Element="SpeedText" ID="Uploadprogresselement6">
                                (calculating)</kw:UploadProgressElement>
								.
							</td>
						</tr>
						<tr>
							<td>
								About
								<kw:UploadProgressElement runat="server" Element="TimeRemainingText" ID="Uploadprogresselement7">
                                (calculating)</kw:UploadProgressElement>
								remaining.
							</td>
						</tr>
						<tr>
							<td>
								<div style="border:1px solid #008800;height:1.5em;position:relative">
									<kw:UploadProgressBarElement runat="server" style="background-color:#00ee00;width:0;height:1.5em" ID="Uploadprogressbarelement1"></kw:UploadProgressBarElement>
									<div style="text-align:center;position:absolute;top:.15em;width:100%">
										<kw:UploadProgressElement runat="server" Element="PercentCompleteText" ID="Uploadprogresselement8">
                                        (calculating)</kw:UploadProgressElement>
									</div>
								</div>
							</td>
						</tr>
					</table>
				</progresstemplate>
			</kw:SlickUpload>
			<hr>
			<asp:Button ID="Button1" runat="server" Text="Upload" />
			&nbsp;<asp:Button ID="cancelButton" runat="server" onclientclick="cancelUpload();return false;" Text="Cancel"
				style="DISPLAY:none" />
			<br>
			<br>
			<asp:Label ID="uploadResult" runat="server"></asp:Label>
			<asp:Repeater ID="uploadFileList" runat="server" EnableViewState="False">
				<FooterTemplate>
					</ul>
				</FooterTemplate>
				<ItemTemplate>
					<li>
						<%# DataBinder.Eval(Container.DataItem, "ClientName") %>
					</li>
				</ItemTemplate>
				<HeaderTemplate>
					<ul>
				</HeaderTemplate>
			</asp:Repeater>
		</form>
	</body>
</HTML>
