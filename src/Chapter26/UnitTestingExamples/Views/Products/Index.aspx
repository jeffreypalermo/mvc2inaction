<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<UnitTestingExamples.Models.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<h2>Products</h2>
    <ul>
		<% foreach (var product in Model) { %>
			<li><%= product.Name %></li>
		<% } %>
    </ul>

</asp:Content>

