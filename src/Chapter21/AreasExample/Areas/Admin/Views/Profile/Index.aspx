<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Profile>>" %>
<%@ Import Namespace="AreasExample.Areas.Admin.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<h2>Profiles</h2>
	<table>
		<tr>
			<th>Username</th>
			<th>First name</th>
			<th>Last name</th>
			<th>Email</th>
		</tr>
		<% foreach (var profile in Model) { %>
		<tr>
			<td><%= profile.Username%></td>
			<td><%= profile.FirstName%></td>
			<td><%= profile.LastName%></td>
			<td><%= profile.Email%></td>
		</tr>
		<% } %>
	</table>
</asp:Content>

