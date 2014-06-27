<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	View Customer
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>View Customer</h2>

    <p>Notice that the URL has the id appended to the URL.  Any additional parameters not identified in a routing rule will show up as querystring arguments,
    such as <%= Html.ActionLink("this link", "show", new{id=123, foo="bar"}) %>.</p>
</asp:Content>
