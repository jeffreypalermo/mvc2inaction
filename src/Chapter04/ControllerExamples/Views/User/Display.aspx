<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Controllers.UserDisplay>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Display
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Display</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Username:
            <%= Html.Encode(Model.Username) %>
        </p>
        <p>
            Name:
            <%= Html.Encode(Model.Name) %>
        </p>
    </fieldset>
</asp:Content>

