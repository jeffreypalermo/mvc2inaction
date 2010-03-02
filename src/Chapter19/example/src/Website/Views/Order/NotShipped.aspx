<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<OrderInfo>" %>
<%@ Import Namespace="Website.Models"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>
<%@ Import Namespace="Website.Controllers"%>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Order Not Shipped
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

The order for product <%= Model.Product %> was not shipped!
<br /><br />
<a href="<%= Url.Action("Index") %>">Return to Order index</a>

</asp:Content>
