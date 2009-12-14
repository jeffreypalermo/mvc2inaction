<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AccountProfile.Models.ProfileSearchModel>" %>

<% using (Html.BeginForm("Find", "Profile", FormMethod.Get)) { %>
	<%= Html.EditorForModel() %>
	<input type="submit" value="Find" />
<% } %>
