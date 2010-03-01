<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Customer>>" %>
<%@ Import Namespace="Core.Domain"%>
<%@ Import Namespace="Microsoft.Web.Mvc"%>
<%@ Import Namespace="Website.Controllers"%>

<asp:Content ID="aboutTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Customer Index
</asp:Content>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">

<% foreach (var customer in Model) { %>

<%= customer.Name %><br />
<%= customer.EmailAddress %><br />
<%= customer.PhoneNumber %><br />
<br /><br />

<% } %>
</asp:Content>
