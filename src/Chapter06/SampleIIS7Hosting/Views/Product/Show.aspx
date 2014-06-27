<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<%@ Import Namespace="SampleIIS7Hosting.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Show
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% var product = (Product) ViewData["product"]; %>

    <h2><%= Html.Encode(product.Name) %></h2>
    <p><%= Html.Encode(product.Description) %></p>

    <%= Html.ActionLink("Back to Product List", "list") %>
</asp:Content>
