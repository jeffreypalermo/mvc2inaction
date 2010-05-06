<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<WidgetInput>" %>
<%@ Import Namespace="Routes.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Edit Widget</h2>
    <% using(Html.BeginForm()) { %>
		Widget Name: <%= Html.TextBox("Name") %> <input type="submit" value="Submit" />
    <% } %>
</asp:Content>
