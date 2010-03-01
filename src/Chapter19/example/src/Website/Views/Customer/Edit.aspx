<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CustomerInput>" %>
<%@ Import Namespace="Website.Models"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Edit Customer
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
<% using (Html.BeginForm("Save", "Customer")) { %>
<%= Html.EditorFor(x => x) %>
<%= Html.SubmitButton() %>
<% } %>
</asp:Content>
