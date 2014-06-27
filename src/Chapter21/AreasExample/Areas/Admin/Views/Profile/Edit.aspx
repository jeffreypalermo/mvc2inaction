<%@ Page Title="" Language="C#"
 MasterPageFile="~/Views/Shared/Site.Master"
 Inherits="System.Web.Mvc.ViewPage<EditProfileInput>" %>
<%@ Import Namespace="AreasExample.Areas.Admin.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>


<% using (Html.BeginForm()) {%>

	<%= Html.EditorForModel() %>
    <p>
		<input type="submit" value="Save" name="SaveButton" />
    </p>

<% } %>

<div>
    <%=Html.ActionLink("Back to List", "Index") %>
</div>
</asp:Content>
