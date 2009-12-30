<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<CustomerInfo>" %>
<%@ Import Namespace="WithAutomapper.Models"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
Customer Name: <%= Model.NameFirst %> <%= Model.NameLast %>
</asp:Content>
