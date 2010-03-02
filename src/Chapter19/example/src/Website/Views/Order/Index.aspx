<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<OrderInfo>>" %>
<%@ Import Namespace="Website.Models"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>
<%@ Import Namespace="Website.Controllers"%>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Order Index
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

<table>
<tr>
<th>Product</th>
<th>Quantity</th>
<th>Status</th>
<th>Ship Date</th>
<th></th>
</tr>
<% foreach (var order in Model) { %>
<tr>
   <td><%= order.Product %></td>
   <td><%= order.Quantity %></td>
   <td><%= order.Status %></td>
   <td><%= order.ShipDate %></td>
   <td>
   <form method="post" action="/order/ship">
   <input type="hidden" name="orderId" value="<%= order.Id %>" />
   <input type="submit" value="Ship" />
   </form>
   </td>
</tr>
<% } %>
</table>
</asp:Content>
