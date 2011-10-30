<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Product[]>" %>
<%@ Import Namespace="Routes.Models"%>

<asp:Content  ContentPlaceHolderID="TitleContent" runat="server">
    View Products
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<h2>All Products</h2>
<table>
    <tr>
        <th>Name</th>
    </tr>
    <% foreach (var product in Model) { %>
    <tr><td><%= product.Name %></td></tr>
    <% } %>
</table>
</asp:Content>
