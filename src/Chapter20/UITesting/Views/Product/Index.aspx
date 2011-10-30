<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ProductListModel[]>" %>
<%@ Import Namespace="UITesting"%>
<%@ Import Namespace="UITesting.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Products
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<input type="hidden" name="pageId" value="<%= LocalSiteMap.Screen.Product.Index %>" />

    <h2>Products</h2>
    <% var products = Model; %>

    <table>
		<thead>
			<tr>
				<td>Details</td>
				<td>Name</td>
				<td>Manufacturer</td>
				<td>Price</td>
			</tr>
		</thead>
		<tbody>
		<% var i = 0; %>
		<% foreach (var product in products) { %>
			<tr>
				<td><%= Html.ActionLink("Edit", "Edit", new { id = product.Id }) %></td>
				<td><%= Html.DisplayFor(m => m[i].Name)%></td>
				<td><%= Html.DisplayFor(m => m[i].ManufacturerName)%></td>
				<td><%= Html.DisplayFor(m => m[i].Price)%></td>
			</tr>
		<%
			i++;
	 } %>
		</tbody>
    </table>

</asp:Content>
