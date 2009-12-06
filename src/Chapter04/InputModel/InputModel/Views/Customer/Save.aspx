<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NewCustomerInput>" %>
<%@ Import Namespace="InputModel.Models"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Customer</h2>
    <div>
        Customer was saved.
    </div>
    <div>First Name: <%= Model.FirstName %></div>
    <div>Last Name: <%= Model.LastName %></div>
    <div>Active: <%= Model.Active %></div>
</asp:Content>
