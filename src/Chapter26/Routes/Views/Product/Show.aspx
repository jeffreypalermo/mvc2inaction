<%@Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Product>" %>
<%@ Import Namespace="Routes.Models"%>

<asp:Content ID="changePasswordTitle" ContentPlaceHolderID="TitleContent" runat="server">
    View Product
</asp:Content>

<asp:Content ID="changePasswordSuccessContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Product: <%= Model.Name %></h2>
    <p>Price: <%= Model.Price.ToString("c") %></p>
</asp:Content>
