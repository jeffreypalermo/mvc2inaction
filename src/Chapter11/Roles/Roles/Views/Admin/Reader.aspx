<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Authorize roles example</h2>
    <p>This is the readers page.  The demo user should never see this because the role is specified on AdminController, even though a compatible role is specified on the action - it is additive.</p>
</asp:Content>
