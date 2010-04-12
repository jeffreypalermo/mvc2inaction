<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UploadStatus>" %>

<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
  Upload Results
</asp:Content>
<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
<p>Result: <%=ViewData.Model.State%></p>
<table class="results" width="99%" cellpadding="4" cellspacing="0">
  <thead>
    <tr>
      <th align="left">Name</th>
      <th align="left">Mime Type</th>
      <th align="left">Length (bytes)</th>
    </tr>
  </thead>
  <tbody>
  <% foreach (UploadedFile file in ViewData.Model.GetUploadedFiles()) { %>
    <tr>
      <td><%=file.ClientName %></td>
      <td><%=file.ContentType %></td>
      <td><%=file.ContentLength %></td>
    </tr>
  <% } %>
  </tbody>
</table>
  <p><%=Html.ActionLink("New Upload", "Index") %></p>
</asp:Content>
