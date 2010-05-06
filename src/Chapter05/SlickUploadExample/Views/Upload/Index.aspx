<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<%@ Register TagPrefix="kw" Assembly="Krystalware.SlickUpload" Namespace="Krystalware.SlickUpload.Controls" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  Home Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    Upload Files</h2>
<% using (Html.BeginForm("UploadResult", "Upload", FormMethod.Post,
     new { id = "uploadForm", enctype = "multipart/form-data" })) { %>
<kw:SlickUpload ID="SlickUpload1" runat="server" 
  UploadFormId="uploadForm" MaxFiles="1"
  ShowDuringUploadElements="cancelButton" 
  HideDuringUploadElements="uploadButton">
  <DownlevelSelectorTemplate>
    <input type="file" />
  </DownlevelSelectorTemplate>
  <UplevelSelectorTemplate>
    <input type="button" value="Add File" />
  </UplevelSelectorTemplate>
  <FileTemplate>
    <kw:FileListRemoveLink runat="server">
      [x] remove</kw:FileListRemoveLink>
    <kw:FileListFileName runat="server" />
    <kw:FileListValidationMessage runat="server" ForeColor="Red" />
  </FileTemplate>
  <ProgressTemplate>
    <table width="99%"><tr><td>
      <p>Upload Progress:</p>
      <div class="progressBorder">
        <kw:UploadProgressBarElement runat="server" CssClass="progressBar"/>
        <div class="progressValue">
          <kw:UploadProgressElement runat="server" Element="PercentCompleteText">
            (calculating)
          </kw:UploadProgressElement>
        </div>
      </div>
    </td></tr></table>
  </ProgressTemplate>
</kw:SlickUpload>
<hr />
<p>
  <input type="submit" value="Upload" id="uploadButton" />
</p>
<% } %>
</asp:Content>
