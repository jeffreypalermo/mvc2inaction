<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master"
Inherits="System.Web.Mvc.ViewPage<IEnumerable<CustomerSummary>>" %>
<%@ Import Namespace="DisplayModel.Models.Presentation"%>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    Customer Summary
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customer Summary</h2>
     <table>
		  <tr>
			  <th>Name</th>
			  <th>Active?</th>
			  <th>Service Level</th>
			  <th>Order Count</th>
			  <th>Most Recent Order Date</th>
		  </tr>

		  <% foreach (var summary in Model) { %>

			  <tr>
					<td><%= summary.FirstName %> <%= summary.LastName %></td>
					<td><%= summary.Active ? "Yes" : "No" %></td>
					<td><%= summary.ServiceLevel %></td>
					<td><%= summary.OrderCount %></td>
					<td><%= summary.MostRecentOrderDate %></td>
			  </tr>

		  <% } %>

     </table>
</asp:Content>
