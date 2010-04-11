<%@ Register Src="Description.ascx" TagPrefix="kw" TagName="Description" %>
<%@ Register Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls"
    TagPrefix="kw" %>
<%@ Import Namespace="Krystalware.SlickUpload.Providers" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Import Namespace="SamplesCS.SqlClient" %>
<%@ Register Src="~/Common/AfterContent.ascx" TagPrefix="kw" TagName="AfterContent" %>
<%@ Register Src="~/Common/MiddleContent.ascx" TagPrefix="kw" TagName="MiddleContent" %>
<%@ Register Src="~/Common/BeforeContent.ascx" TagPrefix="kw" TagName="BeforeContent" %>
<%@ Page Language="c#" AutoEventWireup="true" Inherits="SamplesCS.SqlClient.Default" CodeBehind="Default.aspx.cs" %>
<kw:BeforeContent runat="server" Title="SQL Server Upload" id="BeforeContent1" />
    <form runat="server" ID="Form1">
    <div ID="uploadPanel" runat="server">
        <div id="fileSelectText">Select files to upload:</div>
        <kw:SlickUpload ID="SlickUpload1" runat="server" 
            ShowDuringUploadElements="cancelLink" 
            onuploadcomplete="SlickUpload1_UploadComplete" UploadUrl="~/SqlClient/SlickUpload.axd">
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
            <a id="cancelLink" href="javascript:kw.get('<%=SlickUpload1.ClientID%>').cancel()" style="display:none">Cancel</a>
        </p>
    </div>
    <div ID="resultPanel" runat="server" Visible="false">
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
                            <th align="left">Id</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td><%#((UploadedFile)Container.DataItem).ClientName %></td>
                    <td><%#((UploadedFile)Container.DataItem).ContentType %></td>
                    <td><%#((UploadedFile)Container.DataItem).ContentLength %></td>
                    <td><%#((UploadedFile)Container.DataItem).LocationInfo[SqlClientUploadStreamProvider.IdentityIdKey] %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                    </tbody>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <p><asp:Button id="newUploadButton" runat="server" Text="New Upload" 
                onclick="newUploadButton_Click" /></p>
    </div>
    <h2>Existing files</h2>
    <asp:Repeater ID="filesRepeater" runat="server">
        <HeaderTemplate>
            <table class="results" width="99%" cellpadding="4" cellspacing="0">
                <thead>
                    <th align="left">Name</th>
                    <th align="left">Length (bytes)</th>
                </thead>
                <tbody>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                <td>
                    <a href="DownloadFile.ashx?id=<%# ((RepositoryFile)Container.DataItem).Id %>"><%# ((RepositoryFile)Container.DataItem).Name %></a>
                </td>
                <td>
                    <%# ((RepositoryFile)Container.DataItem).Length %>
                </td>
            </tr>
        </ItemTemplate>
        <FooterTemplate>
                </tbody>
            </table>            
        </FooterTemplate>
    </asp:Repeater>    
    <div id="errorMessage" runat="server" visible="false" enableviewstate="false" style="border:1px solid #c00;padding:.5em;margin-bottom:1em;">
        <b style="color:#f00">ERROR:</b> Could not connect to database. Please ensure the connection string and table information in the web.config are correct and that the file table has been properly created. Exception:<br /> <br />        
    </div>
    </form>
<kw:MiddleContent runat="server" id="MiddleContent1" />
<kw:Description runat="server" id="Description1" />
<kw:AfterContent runat="server" id="AfterContent1" />