<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AccountProfile.Models.Profile>" %>
<tr>
	<td><%= Model.Username %></td>
	<td><%= Model.FirstName%></td>
	<td><%= Model.LastName%></td>
</tr>
