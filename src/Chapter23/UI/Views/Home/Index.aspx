<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>We capture your visit, save it in the database and display the most recent below.</h2>
    <p>
        Click back and forth on the tabs and refresh.  Try switching browsers.  The app will capture the visit.
    </p>
</asp:Content>
