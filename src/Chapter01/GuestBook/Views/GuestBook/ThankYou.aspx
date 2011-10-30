<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	ThankYou
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Thank You!</h2>

    <p>Thank you for signing the guest book!  You entered:</p>
    Name: <%= ViewData["name"] %><br />
    Email: <%= ViewData["email"] %><br />
    Comments: <i><%= ViewData["comments"] %></i>

</asp:Content>
