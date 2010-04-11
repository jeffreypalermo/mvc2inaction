<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of UploadStatus)" %>
<%@ Import Namespace="Krystalware.SlickUpload" %>
<%@ Import Namespace="Krystalware.SlickUpload.Status" %>
<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Upload Results
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <% If ViewData.Model Is Nothing Then%>
    No upload occured.
    <% Else%>
    <p>Result: <%=ViewData.Model.State.ToString()%>
    <%If Not (ViewData.Model.State = UploadState.Complete OrElse ViewData.Model.State = UploadState.PostProcessingComplete) Then%>
    <br />Reason: <%=ViewData.Model.Reason.ToString()%>
    <% End If%>
    <br />Files Uploaded: 
    <% If ViewData.Model.GetUploadedFiles() Is Nothing Then%>
        N/A</p>
    <% Else%>
        <%= ViewData.Model.GetUploadedFiles().Count %></p>
        <table class="results" width="99%" cellpadding="4" cellspacing="0">
            <thead>
                <tr>
                    <th align="left">Name</th>
                    <th align="left">Mime Type</th>
                    <th align="left">Length (bytes)</th>
                </tr>
            </thead>
            <tbody>
            <% For Each file As UploadedFile In ViewData.Model.GetUploadedFiles()%>    
                <tr>
                    <td><%=file.ClientName %></td>
                    <td><%=file.ContentType %></td>
                    <td><%=file.ContentLength %></td>
                </tr>
            <% Next file%>
            </tbody>
        </table>
    <% End If%>
    <% End If%>
    <p><%=Html.ActionLink("New Upload", "Index") %></p>
</asp:Content>
