<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<ValueProvidersExample.Models.Profile[]>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Profiles
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Profiles</h2>
    <table>
		<tr>
			<th>&nbsp;</th>
			<th>Username</th>
			<th>First name</th>
			<th>Last name</th>
			<th>Email</th>
		</tr>
		<% foreach (var profile in Model) { %>
		<tr>
			<td><%= Html.ActionLink("View Details", "Show", new{ username = profile.Username }) %></td>
			<td><%= profile.Username %></td>
			<td><%= profile.FirstName %></td>
			<td><%= profile.LastName %></td>
			<td><%= profile.Email %></td>
		</tr>		
		<% } %>
    </table>

</asp:Content>
