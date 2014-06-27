<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Guest Book</h2>

    <p>Please sign the Guest Book!</p>

    <form method="post" action="/GuestBook/Sign">
    <fieldset>
        <legend>Guest Book</legend>

        <%= Html.Label("Name") %>
        <%= Html.TextBox("Name") %>

        <%= Html.Label("Email") %>
        <%= Html.TextBox("Email") %>

        <%= Html.Label("Comments") %>
        <%= Html.TextArea("Comments", new { rows=6, cols=30 }) %>

        <div>
        <input type="submit" value="Sign" />
        </div>
    </fieldset>
    </form>

</asp:Content>
