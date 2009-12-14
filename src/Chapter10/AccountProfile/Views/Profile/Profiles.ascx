<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<AccountProfile.Models.Profile>>" %>

<h2>Profiles</h2>
<table>
	<tr>
		<th>Username</th>
		<th>First name</th>
		<th>Last name</th>
		<th>Email</th>
	</tr>
	<% foreach (var profile in Model) { %>
		<% Html.RenderPartial("Profile", profile); %>
	<% } %>
</table>