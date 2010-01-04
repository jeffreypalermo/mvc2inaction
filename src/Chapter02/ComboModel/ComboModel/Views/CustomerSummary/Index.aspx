<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<CustomerSummary>>" %>
<%@ Import Namespace="ComboModel.Models"%>

<asp:Content ID="Title" ContentPlaceHolderID="TitleContent" runat="server">
    Customer Summary
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customer Summary</h2>
    <form action="<%= Url.Action("Save") %>" method="post">
     <table>
		  <tr>
			  <th>Name</th>
			  <th>Service Level</th>
			  <th>Order Count</th>
			  <th>Most Recent Order Date</th>
			  <th>Active?</th>
		  </tr>
		  
		  <% int index = 0; foreach (var summary in Model) { %>
		  
			  <tr>
					<td><%= summary.FirstName %> <%= summary.LastName %></td>
					<td><%= summary.ServiceLevel %></td>
					<td><%= summary.OrderCount %></td>
					<td><%= summary.MostRecentOrderDate %></td>
					<td>
						<%= Html.CheckBox("input[" + index + "].Active", summary.Active) %>
						<input type="hidden" value="<%= summary.Number %>" name="<%= "input[" + index + "].Number" %>" value="<%= summary.Number %>" />
					</td>
			  </tr>
		  
		  <% index++; } %>
		  
     </table>
     <button name="submit">Change Status</button>
     </form>
</asp:Content>