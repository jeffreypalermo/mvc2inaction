<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<ChangePasswordModel>" %>
<%@ Import Namespace="AccountProfile.Models"%>
<p>
	<%= Html.EditorFor(m => m.OldPassword) %>
</p>
<p>
	<%= Html.EditorFor(m => m.NewPassword) %>
</p>
<p>
	<%= Html.EditorFor(m => m.ConfirmPassword) %>
</p>