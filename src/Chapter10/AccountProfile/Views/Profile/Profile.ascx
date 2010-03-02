<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Profile>" %>
<tr>
    <td>
		<%= Html.ActionLink(Model.Username, "Show", new{ username = Model.Username }) %>
	</td>
    <td><%= Model.FirstName%></td>
    <td><%= Model.LastName%></td>
    <td><%= Model.Email %></td>
</tr>
