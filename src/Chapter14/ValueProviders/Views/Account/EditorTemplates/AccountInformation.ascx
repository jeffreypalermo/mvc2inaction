<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ChangePasswordModel>" %>
<%@ Import Namespace="ValueProvidersExample.Models"%>
<p>
	<%= Html.EditorFor(m => m.OldPassword) %>
</p>
<p>
	<%= Html.EditorFor(m => m.NewPassword) %>
</p>
<p>
	<%= Html.EditorFor(m => m.ConfirmPassword) %>
</p>