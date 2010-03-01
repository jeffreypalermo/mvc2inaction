<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewPage<ProfileBase>" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h3>Edit my profile</h3>
<% using(Html.BeginForm("save", "profile")) {%>
    <label for="nickName">Nick Name:</label> <%= Html.TextBox("nickName") %><br />
    <label for="age">Age:</label> <%= Html.TextBox("age") %><br />
    <input type="submit" value="save" />
<% } %>
</asp:Content>
