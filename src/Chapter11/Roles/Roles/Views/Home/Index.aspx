<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Authorize roles example</h2>
    <p>Log on with username "demo" and password "password"</p>
    <p>The about page requires authorization</p>
    <p>The developers page requires the "developers" role - the demo user has this role</p>
    <p>The admins page requires the "admins" role - the demo user does not have this role</p>
</asp:Content>
