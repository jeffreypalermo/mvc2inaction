<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginUserControl.ascx.cs" Inherits="Personalization.Views.Shared.LoginUserControl" %>
<%
    if (Request.IsAuthenticated) {
%>
        Welcome <b><%= Html.Encode(Page.User.Identity.Name) %></b>!
        [ <%= Html.ActionLink("Logout", "Logout", "Account") %> ]
<%
    }
    else {
%>
        [ <%= Html.ActionLink("Login", "Login", "Account") %> ]
<%
    }
%>
