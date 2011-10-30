<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<SmartBindersExample.Models.ProfileEditModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>


    <% using (Html.BeginForm("Save", "Profile")) {%>

		<%= Html.EditorForModel() %>
        <p>
			<button type="submit" value="Save" name="SaveButton">Save</button>
			<button type="submit" value="SaveAndClose" name="SaveButton">Save and Close</button>
        </p>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

