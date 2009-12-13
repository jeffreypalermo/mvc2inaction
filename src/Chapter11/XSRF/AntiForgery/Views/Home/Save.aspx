<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<InputModel>" %>
<%@ Import Namespace="AntiForgery.Controllers"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Saved!
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
	<h1>You saved: <%= Html.Encode(Model.Name) %></h1>
</asp:Content>
