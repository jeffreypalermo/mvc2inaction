<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<NewCustomerInput>" %>
<%@ Import Namespace="InputModel.Models"%>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>New Customer</h2>
    <form action="<%= Url.Action("Save") %>" method="post">
		 <div><%= Html.LabelFor(x => x.FirstName) %> <%= Html.TextBoxFor(x => x.FirstName) %></div>
		 <div><%= Html.LabelFor(x => x.LastName) %> <%= Html.TextBoxFor(x => x.LastName) %></div>
		 <div><%= Html.LabelFor(x => x.Active) %> <%= Html.CheckBox("Active") %></div>
		 <div><input type="submit" value="Save" /></div>
    </form>
</asp:Content>
