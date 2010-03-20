<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProductForm>" %>
<%@ Import Namespace="UITesting.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Product</h2>
	
	<% using (Html.BeginForm()) { %>
		<%= Html.EditorForModel()%>
		<input type="submit" value="Save" />
    <% } %>
</asp:Content>
