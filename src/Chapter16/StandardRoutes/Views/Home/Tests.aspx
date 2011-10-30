<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Tests
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Testing Routes</h2>

    <p>Be sure to check out the unit tests for these routes.  They are located in the <b>StandardRoutes.Tests</b> project.</p>

    <p>The unit tests take advantage of MvcContrib, to provide a friendly route testing API that is easy to use.</p>

</asp:Content>
