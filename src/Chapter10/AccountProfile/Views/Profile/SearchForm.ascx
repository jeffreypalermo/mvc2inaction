<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AccountProfile.Models.ProfileSearchCriteria>" %>

<% using (Html.BeginForm("Find", "Profile", FormMethod.Get)) { %>
	<%= Html.EditorForModel() %>
	<input type="submit" value="Find" />
<% } %>
