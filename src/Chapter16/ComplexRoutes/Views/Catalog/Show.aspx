<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Widget>" %>
<%@ Import Namespace="ComplexRoutes.Models"%>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Show
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Widget Details</h1>
    
    <h2>Code:  <%= Html.Encode(Model.Code) %></h2>
    <h2>Name:  <%= Html.Encode(Model.Name) %></h2>
    
</asp:Content>
