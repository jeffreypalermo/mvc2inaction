<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="SampleIIS7Hosting.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Product List</h2>

    <table>
        <tr>
            <th>Name</th>
            <th>Description</th>
        </tr>
        <% foreach(var product in ((IEnumerable<Product>)ViewData["products"])) { %>
        <tr>
            <td><%= Html.ActionLink(Html.Encode(product.Name), "show", new{id=product.Id}) %></td>
            <td><%= Html.Encode(product.Description) %></td>
        </tr>
        <% } %>
    </table>

</asp:Content>
