<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ProfileSearchCriteria>" %>

<% using (Html.BeginForm("Find", "Profile", FormMethod.Get)) { %>
	<%= Html.EditorForModel() %>
	<input type="submit" value="Find" />
<% } %>
